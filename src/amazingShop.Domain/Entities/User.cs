using System.Collections.Generic;

namespace amazingShop.Domain.Entities
{
    public sealed class User : EntityBase
    {

        public User(long id) : base(id)
        {
            Name = Email = default!;
        }
        public User(string name, string email)
            => (Name, Email) = (name, email);

        public User(string name, string email, byte[] password, byte[] salt)
            => (Name, Email, Password, Salt) = (name, email, password, salt);

        public User(long id, string name, string email, byte[]? password, byte[]? salt) : base(id)
        {
            Name = name;
            Email = email;
            Password = password;
            Salt = salt;
        }

        public string Name { get; }

        public string Email { get; }

        public IEnumerable<Product> Products { get; } = default!;

        public byte[]? Password { get; }

        public byte[]? Salt { get; }
    }
}