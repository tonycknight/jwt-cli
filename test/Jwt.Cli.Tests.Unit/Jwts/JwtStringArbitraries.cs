using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using FsCheck;
using FsCheck.Fluent;

namespace Jwt.Cli.Tests.Unit.Jwts
{
    internal static class JwtStringArbitraries
    {
        public const string Issuer = "arbitrary";

        public static Arbitrary<string> GetArbitrary()
        {
            var handler = new JwtSecurityTokenHandler();

            return ArbMap.Default.ArbFor<Guid>()
                       .Generator
                       .Select(g => handler.CreateJwtSecurityToken(audience: g.ToString(), issuer: Issuer))
                       .Select(jwt => handler.WriteToken(jwt))
                       .ToArbitrary();
        }
    }
}
