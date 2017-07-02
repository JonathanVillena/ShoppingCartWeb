using System;

namespace ShoppingCartWeb.Options
{
    public class TokenOptions
    {
        public string Type { get; set; } = "Bearer";
        public TimeSpan ValidFor { get; set; } = TimeSpan.FromHours(1);
        public string Audience { get; set; } = "http://localhost:44307";
        public string Issuer { get; set; } = "ShoppingCart";
        public string SigningKey { get; set; } = "cc4435685b40b2e9ddcb357fd79423b2d8e293b897d86f5336cb61c5fd31c9a3";
    }
}