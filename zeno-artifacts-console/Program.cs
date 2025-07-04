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
                .Bind(hostContext.Configuration.GetSection(ArtifactsSettings.Path));

            // TODO: Validate
            // Validator.ValidateObject(appSettings, new ValidationContext(appSettings), validateAllProperties: true);

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
    private readonly ArtifactsApiClient _artifactsApiClient;

    public Worker(
        IHostApplicationLifetime hostApplicationLifetime,
        ICacheableService<MapSchema> mapService,
        ICacheableService<MonsterSchema> monsterService,
        ArtifactsApiClient artifactsApiClient)
    {
        _hostApplicationLifetime = hostApplicationLifetime;
        _mapService = mapService;
        _monsterService = monsterService;
        _artifactsApiClient = artifactsApiClient;
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

        var weakestMonster = monsters.MinBy(_ => _.Hp);

        var mapWithMonster = maps.FirstOrDefault(_ => _.Content?.Code == weakestMonster!.Code);

        var charactersByName = characters?.Data?.ToDictionary(_ => _.Name!, _ => _) ?? [];

        {
            var character = charactersByName["Zenot"];

            if (mapWithMonster is { } map && (character.X != map.X || character.Y != map.Y))
            {
                var response = await _artifactsApiClient.My[character.Name].Action.Move.PostAsync(
                    new DestinationSchema
                    {
                        X = mapWithMonster.X,
                        Y = mapWithMonster.Y
                    },
                    _ => { },
                    token);

                await Task.Delay(TimeSpan.FromSeconds(response?.Data?.Cooldown?.RemainingSeconds ?? 5), token);
            }
        }

        _hostApplicationLifetime.StopApplication();
    }
}