using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using amazingShop.Api.Commands.Users;
using amazingShop.Api.Dtos;
using amazingShop.Api.Rules;
using amazingShop.Domain.Core.Notifications;
using amazingShop.Domain.Core.Validators;
using amazingShop.Domain.Entities;
using amazingShop.Domain.Repositories;

namespace amazingShop.Api.Services.Users
{
    public class AuthenticationService : IAuthenticationService
    {
        public User Register(string name, string email, string password)
        {
            byte[] hashed, salt;
            CreateHash(password, out hashed, out salt);

            return new User(name, email, hashed, salt);
        }

        private void CreateHash(string password, out byte[] hashed, out byte[] salt)
        {
            using (var sha512 = new HMACSHA512())
            {
                salt = sha512.Key;
                hashed = sha512.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
    }
}