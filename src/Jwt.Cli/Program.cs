using System.Diagnostics.CodeAnalysis;
using McMaster.Extensions.CommandLineUtils;
using Jwt.Cli.Commands;
using Tk.Extensions;


namespace Jwt.Cli
{
    [ExcludeFromCodeCoverage]
    public class Program
    {
        public static async Task<int> Main(string[] args)
        {
            using var app = new CommandLineApplication<DecodeJwtCommand>()
            {
                UnrecognizedArgumentHandling = UnrecognizedArgumentHandling.Throw,
                MakeSuggestionsInErrorMessage = true,
            };

            app.Conventions
                .UseDefaultConventions()
                .UseConstructorInjection(ProgramBootstrap.CreateServiceCollection());
            app.ExtendedHelpText = await app.GetPackageInfoAsync();

            try
            {
                return app.Execute(args);
            }
            catch (UnrecognizedCommandParsingException ex)
            {
                Console.WriteLine(Crayon.Output.Bright.Red(ex.Message));
                var possibleMatches = ex.NearestMatches.Select(m => $"{app.Name} {m}").Join(Environment.NewLine);
                if (possibleMatches.Length > 0)
                {
                    Console.WriteLine(Crayon.Output.Bright.Yellow($"Did you mean one of these commands?{Environment.NewLine}{possibleMatches}"));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(Crayon.Output.Bright.Red(ex.Message));
            }
            return false.ToReturnCode();
        }


        private int OnExecute(CommandLineApplication app)
        {
            app.ShowHelp();

            return true.ToReturnCode();
        }
    }
}