namespace zeno.artifacts.shared.Services;

public record Npc(NPCSchema Schema, List<NPCItem> Items);

public sealed class NpcService(ArtifactsApiClient client) : CacheableService<Npc>(client)
{
    protected override string CacheFileName => "npc.json";

    protected override async Task<List<Npc>> GetAll(CancellationToken cancellationToken)
    {
        var npcData = await Client.Npcs.Details.GetAsync(
            _ => _.QueryParameters.Page = 1,
            cancellationToken);

        List<NPCSchema> npcList = npcData?.Data is not null ? [.. npcData.Data] : [];

        for (var page = 2; page <= (npcData?.Pages?.Integer ?? 1); ++page)
        {
            var additionalNpcs = await Client.Npcs.Details.GetAsync(
                _ => _.QueryParameters.Page = page,
                cancellationToken);

            if (additionalNpcs?.Data is { } moreNpcs)
            {
                npcList.AddRange(moreNpcs);
            }
        }

        var npcItems = await Client.Npcs.Items.GetAsync(
            _ => _.QueryParameters.Page = 1,
            cancellationToken);

        List<NPCItem> itemsList = npcItems?.Data is not null ? [.. npcItems.Data] : [];

        for (var page = 2; page <= (npcItems?.Pages?.Integer ?? 1); ++page)
        {
            var additionalItems = await Client.Npcs.Items.GetAsync(
                _ => _.QueryParameters.Page = page,
                cancellationToken);

            if (additionalItems?.Data is { } moreItems)
            {
                itemsList.AddRange(moreItems);
            }
        }

        return [.. npcList.Select(_ => new Npc(_, [.. itemsList.Where(i => i.Npc == _.Code)]))];
    }
}
