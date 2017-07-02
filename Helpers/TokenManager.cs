using System;
using System.Text;
using ShoppingCartWeb.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace ShoppingCartWeb.Helpers
{
    public static class TokenManager
    {
        private static byte[] GetSigningKeyBytes(TokenOptions options){
            return Encoding.ASCII.GetBytes(options.SigningKey);
        }
        private static SymmetricSecurityKey GetSymmetricSecurityKey(TokenOptions options){
            return new SymmetricSecurityKey(GetSigningKeyBytes(options));
        }
        private static SigningCredentials GetSigningCredentials(TokenOptions options){
            return new SigningCredentials(GetSymmetricSecurityKey(options), SecurityAlgorithms.HmacSha256);
        }

        public static string RequestToken()
        {
            TokenOptions options = new TokenOptions();

            var token = new JwtSecurityToken(
                audience: options.Audience,
                issuer: options.Issuer,
                expires: DateTime.UtcNow.Add(options.ValidFor),
                signingCredentials: GetSigningCredentials(options));
            
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}