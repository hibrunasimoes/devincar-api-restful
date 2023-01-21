using System;
using DEVinCar.Domain.Security;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace DEVinCar.Domain.Services
{
	public class RefreshTokenService
	{
        public static ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Settings.Secret)),
                ValidateIssuer = false,
                ValidateAudience = false,
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var secutiryToken);

            if (secutiryToken is not JwtSecurityToken jwtSecurityToken)
                throw new SecurityTokenException("Invalid token");

            return principal;
        }

        public static string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        private static List<Tuple<string, string>> _refreshsTokens = new List<Tuple<string, string>>();

        public static void SaveRefreshToken(string username, string refreshToken)
            => _refreshsTokens.Add(new Tuple<string, string>(username, refreshToken));

        public static string GetRefreshToken(string username)
            => _refreshsTokens.FirstOrDefault(x => x.Item1 == username).Item2;

        public static void DeleteRefreshToken(string username, string refreshToken)
        {
            var item = _refreshsTokens.FirstOrDefault(x => x.Item1 == username && x.Item2 == refreshToken);
            _refreshsTokens.Remove(item);
        }
    }
}

