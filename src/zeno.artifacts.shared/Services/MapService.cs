namespace zeno.artifacts.shared.Services;

public sealed class MapService(ArtifactsApiClient client) : CacheableService<MapSchema>(client)
{
    protected override async Task<List<MapSchema>> GetAll(CancellationToken cancellationToken)
    {
        var maps = await Client.Maps.GetAsync(
            _ => _.QueryParameters.Page = 1,
            cancellationToken);

        List<MapSchema> mapList = maps?.Data is not null ? [.. maps.Data] : [];

        for (var page = 2; page <= (maps?.Pages?.Integer ?? 1); ++page)
        {
            var additionalMaps = await Client.Maps.GetAsync(
                _ => _.QueryParameters.Page = page,
                cancellationToken);

            if (additionalMaps?.Data is { } moreMapSchemas)
            {
                mapList.AddRange(moreMapSchemas);
            }
        }

        return mapList;
    }

    protected override string CacheFileName => "maps.json";
}
