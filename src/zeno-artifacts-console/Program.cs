using System.ComponentModel.DataAnnotations;
using zeno.artifacts.shared;
using zeno.artifacts.shared.Configuration;
using zeno.artifacts.shared.Ignition;
using zeno.artifacts.shared.Services;
using Zeno.Artifacts.Shared.Client;
using Zeno.Artifacts.Shared.Client.Models;

namespace zeno_artifacts_console;

internal class Program
{
    static async Task Main(string[] args)
    {
        var host = CreateDefaultApp(args).Build();
        await host.RunAsync();
    }

    private static IHostBuilder CreateDefaultApp(string[] args) => Host
        .CreateDefaultBuilder()
        .ConfigureAppConfiguration((hostingContext, configurationBuilder) =>
        {
            configurationBuilder
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile("appsettings.development.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .AddCommandLine(args);
        })
        .ConfigureServices((hostContext, services) =>
        {
            services
                .AddOptions<ArtifactsSettings>()
                .Bind(hostContext.Configuration.GetSection(ArtifactsSettings.Path))
                .Validate(_ => Validator.TryValidateObject(_, new ValidationContext(_), [], validateAllProperties: true));

            services
                .AddShared()
                .AddHostedService<Worker>();
        })
        .ConfigureLogging(logging =>
        {
            logging.ClearProviders();
            logging.AddConsole();
        });
}

public class Worker : BackgroundService
{
    private readonly IHostApplicationLifetime _hostApplicationLifetime;
    private readonly ICacheableService<MapSchema> _mapService;
    private readonly ICacheableService<MonsterSchema> _monsterService;
    private readonly ICacheableService<Npc> _npcService;
    private readonly ArtifactsApiClient _artifactsApiClient;
    private readonly ILogger<Worker> _logger;

    public Worker(
        IHostApplicationLifetime hostApplicationLifetime,
        ICacheableService<MapSchema> mapService,
        ICacheableService<MonsterSchema> monsterService,
        ICacheableService<Npc> npcService,
        ArtifactsApiClient artifactsApiClient,
        ILogger<Worker> logger)
    {
        _hostApplicationLifetime = hostApplicationLifetime;
        _mapService = mapService;
        _monsterService = monsterService;
        _npcService = npcService;
        _artifactsApiClient = artifactsApiClient;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken token)
    {
        var location = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), Constants.SpecialFolderName);
        if (!Directory.Exists(location))
        {
            Directory.CreateDirectory(location);
        }

        var serverDetails = await _artifactsApiClient.GetAsync(cancellationToken: token);

        var myDetails = await _artifactsApiClient.My.Details.GetAsync(cancellationToken: token);

        var characters = await _artifactsApiClient.My.Characters.GetAsync(cancellationToken: token);

        var monsters = await _monsterService.GetAllThroughCache(token);

        var maps = await _mapService.GetAllThroughCache(token);

        var mapsWithContent = maps.Where(_ => _.Content is not null).ToList();

        var npcs = await _npcService.GetAllThroughCache(token);

        var items = npcs.SelectMany(_ => _.Items).DistinctBy(_ => _.Code).Select(_ => _.Code).ToList();

        var contentType = maps
            .Where(_ =>
                _.Content is not null &&
                _.Content.Type == MapContentType.Npc)
            .ToList();

        var weakestMonster = monsters.MinBy(_ => _.Hp);

        var mapWithMonster = maps.FirstOrDefault(_ => _.Content?.Code == weakestMonster!.Code);

        var charactersByName = characters?.Data?.ToDictionary(_ => _.Name!, _ => _) ?? [];

        const string CharacterName = "Zenot";

        {
            var character = charactersByName[CharacterName];

            await TODO_TEMP_SellAll(npcs, maps, character, token);

            const int total = 1000;
            foreach (var i in Enumerable.Range(0, total))
            {
                _logger.LogInformation("Starting round {Round}/{Total}", i + 1, total);

                if (mapWithMonster is { X: not null, Y: not null } map && (character.X != map.X || character.Y != map.Y))
                {
                    character = await Move(mapWithMonster.X.Value, mapWithMonster.Y.Value, character, token);
                }

                character = await WaitForCooldown(character, token);

                character = await HealCharacter(character, token);

                character = await WaitForCooldown(character, token);

                character = await Fight(character, token);

                character = await WaitForCooldown(character, token);

                character = await HealCharacter(character, token);

                character = await WaitForCooldown(character, token);

                _logger.LogInformation("Completed round {Round}/{Total}", i + 1, total);
            }
        }

        _hostApplicationLifetime.StopApplication();
    }

    private async Task<CharacterSchema> TODO_TEMP_SellAll(List<Npc> nps, List<MapSchema> maps, CharacterSchema character, CancellationToken token)
    {
        foreach (var i in character.Inventory ?? [])
        {
            var npcsThatBuy = nps.Where(_ => _.Items.Any(ii => ii.Code == i.Code)).ToList();
            if (npcsThatBuy.Count is 0)
            {

            }
        }

        /*
         * TODO: Can't actually sell everything,
         * so need to either use it (craft using it) or bank it
         * If using it maybe we prioritize making something that only uses it as a recipe item?
         * Or maybe have a user defined dictionary/map of what to do with each item?
         * So 
         *  - eggs are get more than 5 and make cooked eggs
         *  - feathers are make the gloves that only take feathers
         *  - raw chicken is cook chicken
         *  - golden eggs are sell to artifact trader/npc 
         * Might be that these are level specific? Or only when a buffer/stockpile is made 
         * in the bank, spend the excess etc?
         */

        // TODO: Need to find npc who buys things
        //await _artifactsApiClient.My[character.Name].Action.Npc.Sell.PostAsync(
        //    new NpcMerchantBuySchema
        //    {
        //        Code = "",
        //        Quantity = 0
        //    },
        //    cancellationToken: token);

        return character;
    }

    private async Task<CharacterSchema> Move(int x, int y, CharacterSchema character, CancellationToken token)
    {
        var response = await _artifactsApiClient.My[character.Name].Action.Move.PostAsync(
            new DestinationSchema { X = x, Y = y },
            _ => { },
            token);

        if (response?.Data?.Character is not null)
        {
            character = response.Data.Character;
        }

        return character;
    }

    private async Task<CharacterSchema> Fight(CharacterSchema character, CancellationToken token)
    {
        var fightResponse = await _artifactsApiClient.My[character.Name].Action.Fight.PostAsync(
                        _ => { },
                        token);

        if (fightResponse?.Data is { } fightData)
        {
            if (fightData.Character is not null)
            {
                character = fightData.Character;
            }
        }

        return character;
    }

    private async Task<CharacterSchema> HealCharacter(CharacterSchema character, CancellationToken token)
    {
        if (character.Hp < character.MaxHp)
        {
            if (await _artifactsApiClient.My[character.Name].Action.Rest.PostAsync(cancellationToken: token) is { Data: not null } restData &&
                restData.Data.Character is not null)
            {
                character = restData.Data.Character;
            }
        }

        return character;
    }

    private async Task<CharacterSchema> WaitForCooldown(CharacterSchema character, CancellationToken token)
    {
        if (character.CooldownExpiration <= DateTimeOffset.UtcNow)
        {
            return character;
        }

        await Task.Delay(TimeSpan.FromSeconds(1 + (character.Cooldown ?? 0)), token);

        var response = await _artifactsApiClient.Characters[character.Name].GetAsync(cancellationToken: token);

        return response?.Data ?? throw new InvalidDataException("Could not retrieve character");
    }
}