namespace zeno.artifacts.shared.Ignition;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddShared(this IServiceCollection services)
    {
        services.AddSingleton<ICacheableService<MapSchema>, MapService>();
        services.AddSingleton<ICacheableService<MonsterSchema>, MonsterService>();
        services.AddSingleton<ArtifactsApiClient>(_ =>
        {
            var options = _.GetRequiredService<IOptions<ArtifactsSettings>>();
            var authToken = options.Value.TOKEN;

            var authenticationProvider = new ApiKeyAuthenticationProvider(
                $"Bearer {authToken}",
                "Authorization",
                ApiKeyAuthenticationProvider.KeyLocation.Header);

            var requestAdapter = new HttpClientRequestAdapter(authenticationProvider)
            {
                BaseUrl = options.Value.BASE_URL
            };

            return new ArtifactsApiClient(requestAdapter);
        });

        return services;
    }
}
