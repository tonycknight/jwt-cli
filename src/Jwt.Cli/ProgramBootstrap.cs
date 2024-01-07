using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console;
using Tk.Nuget;

namespace Jwt.Cli
{
    internal static class ProgramBootstrap
    {
        public static IServiceProvider CreateServiceCollection() =>
           new ServiceCollection()
                .AddSingleton<Jwts.IJwtParser, Jwts.JwtParser>()
                .AddSingleton<IAnsiConsole>(sp => AnsiConsole.Create(new AnsiConsoleSettings() { ColorSystem = ColorSystemSupport.TrueColor }))
                .BuildServiceProvider();

        public static string? GetAppVersion()
            => Assembly.GetExecutingAssembly()
                       .GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion
                       .ToVersion().ToString();
    }
}
