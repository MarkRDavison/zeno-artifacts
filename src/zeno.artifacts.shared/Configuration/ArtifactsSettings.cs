namespace zeno.artifacts.shared.Configuration;

public sealed class ArtifactsSettings
{
    public const string Path = "ARTIFACTS";

    public required string BASE_URL { get; set; }
    public required string TOKEN { get; set; }
}
