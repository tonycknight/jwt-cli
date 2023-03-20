using McMaster.Extensions.CommandLineUtils;
using Spectre.Console;
using Jwt.Cli.Jwts;

namespace Jwt.Cli.Commands
{
    [Command("jwt", Description = "Decode a JWT")]
    internal class DecodeJwtCommand
    {
        private readonly IAnsiConsole _console;
        private readonly IJwtParser _jwtParser;

        public DecodeJwtCommand(IAnsiConsole console, IJwtParser jwtParser)
        {
            _console = console;
            _jwtParser = jwtParser;
        }

        [Argument(0, Description = "The JWT to decode.", Name = "jwt")]
        public string? Jwt { get; set; }

        public int OnExecute(CommandLineApplication app)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Jwt))
                {
                    app.ShowHelp();
                    return false.ToReturnCode();
                }

                var lines = _jwtParser.Parse(this.Jwt)
                                      .Select(t => (t.Item1, t.Item2))
                                      .ToSpectreColumns();

                _console.Write(lines);

                return true.ToReturnCode();
            }
            catch (Exception)
            {
                _console.Write(new Markup($"[red]Invalid JWT.[/]"));
                return false.ToReturnCode();
            }
        }
    }
}
