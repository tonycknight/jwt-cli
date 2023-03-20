namespace Jwt.Cli.Jwts
{
    internal interface IJwtParser
    {
        IEnumerable<(string, string)> Parse(string jwt);
    }
}
