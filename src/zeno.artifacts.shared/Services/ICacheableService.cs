namespace zeno.artifacts.shared.Services;

public interface ICacheableService<T>
{
    public void ClearCache();
    public Task<List<T>> GetAllThroughCache(CancellationToken cancellationToken);
}
