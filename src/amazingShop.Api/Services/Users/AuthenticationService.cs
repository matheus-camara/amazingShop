using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using amazingShop.Api.Settings;
using amazingShop.Domain.Entities;
using Microsoft.IdentityModel.Tokens;

namespace amazingShop.Api.Services.Users
{
    public class AuthenticationService : IAuthenticationService
    {
        public AppSettings _appSettings;

        public User Register(string name, string email, string password)
        {
            byte[] hashed, salt;
            CreateHash(password, out hashed, out salt);

            return new User(name, email, hashed, salt);
        }

        public string? Login(User user, string password)
        {
            if (user.Salt is null || user.Password is null || !CheckPassword(user.Salt, user.Password, password)) return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.SigningKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.PrimarySid, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Name),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
        }

        private bool CheckPassword(byte[] salt, byte[] passwordHash, string password)
        {
            using (var hmac = new HMACSHA512(salt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i]) return false;
                }
            }

            return true;
        }

        private void CreateHash(string password, out byte[] hashed, out byte[] salt)
        {
            using (var sha512 = new HMACSHA512())
            {
                salt = sha512.Key;
                hashed = sha512.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        public AuthenticationService(AppSettings appSettings)
        {
            _appSettings = appSettings;
        }
    }
}