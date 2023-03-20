namespace Jwt.Cli.Nuget
{
    internal interface INugetClient
    {
        Task<string?> GetLatestNugetVersionAsync(string packageId, string? sourceUrl = null);
    }
}
