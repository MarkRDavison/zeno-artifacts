namespace zeno.artifacts.shared.Services;

public sealed class MonsterService(ArtifactsApiClient client) : CacheableService<MonsterSchema>(client)
{
    protected override async Task<List<MonsterSchema>> GetAll(CancellationToken cancellationToken)
    {
        var data = await Client.Monsters.GetAsync(
            _ => _.QueryParameters.Page = 1,
            cancellationToken);

        List<MonsterSchema> dataList = data?.Data is not null ? [.. data.Data] : [];

        for (var page = 2; page <= (data?.Pages?.Integer ?? 1); ++page)
        {
            var additionalMaps = await Client.Monsters.GetAsync(
                _ => _.QueryParameters.Page = page,
                cancellationToken);

            if (additionalMaps?.Data is { } moreMapSchemas)
            {
                dataList.AddRange(moreMapSchemas);
            }
        }

        return dataList;
    }

    protected override string CacheFileName => "monsters.json";
}
