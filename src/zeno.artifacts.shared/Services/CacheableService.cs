using System.Text.Json;

namespace zeno.artifacts.shared.Services;

public record CacheData<T>(DateTime Date, List<T> Data);

public abstract class CacheableService<T> : ICacheableService<T>
{
    protected CacheableService(ArtifactsApiClient client)
    {
        Client = client;
    }

    public void ClearCache()
    {
        throw new NotImplementedException();
    }

    protected async Task<CacheData<T>?> GetCached<T>()
    {
        var fileLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), Constants.SpecialFolderName, CacheFileName);

        if (!File.Exists(fileLocation))
        {
            return null;
        }

        var fileData = await File.ReadAllTextAsync(fileLocation);

        var data = JsonSerializer.Deserialize<CacheData<T>>(fileData, new JsonSerializerOptions());

        return data;
    }

    protected async Task WriteCache<T>(List<T> data)
    {
        var fileLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), Constants.SpecialFolderName, CacheFileName);

        var text = JsonSerializer.Serialize(
            new CacheData<T>(DateTime.Now, data),
            new JsonSerializerOptions());

        await File.WriteAllTextAsync(fileLocation, text, CancellationToken.None);
    }

    public async Task<List<T>> GetAllThroughCache(CancellationToken cancellationToken)
    {
        var cached = await GetCached<T>();

        if (cached is not null)
        {
            return cached.Data;
        }

        var data = await GetAll(cancellationToken);

        await WriteCache(data);

        return data;
    }

    protected abstract Task<List<T>> GetAll(CancellationToken cancellationToken);

    protected ArtifactsApiClient Client { get; }
    protected abstract string CacheFileName { get; }
}
