using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console;

namespace Jwt.Cli
{
    internal static class ProgramBootstrap
    {
        public static IServiceProvider CreateServiceCollection() =>
           new ServiceCollection()
                .AddSingleton<Jwts.IJwtParser, Jwts.JwtParser>()
                .AddSingleton<IAnsiConsole>(sp => AnsiConsole.Create(new AnsiConsoleSettings() { ColorSystem = ColorSystemSupport.TrueColor }))
                .AddSingleton<Nuget.INugetClient, Nuget.NugetClient>()
                .BuildServiceProvider();

        public static string? GetAppVersion()
            => Assembly.GetExecutingAssembly()
                       .GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion;

        public static Task<string?> GetCurrentNugetVersion()
            => new Nuget.NugetClient().GetLatestNugetVersionAsync("jwt-cli");
    }
}
