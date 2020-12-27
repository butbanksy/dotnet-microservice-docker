using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using UsersMicroservice.Models;
using Microsoft.Extensions.Configuration;


namespace UsersMicroservice.Services
{
    public class JWTService : IJWTService
    {
        private readonly IConfiguration _config;

        public JWTService(IConfiguration config)
        {
            _config = config;
        }

        public string GenerateJSONWebToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                new Claim("sub", user.Id.ToString())
            };


            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}