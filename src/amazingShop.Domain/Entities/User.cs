namespace amazingShop.Domain.Entities
{
    public sealed class User : EntityBase
    {
        public User(string name, string email)
            => (Name, Email) = (name, email);

        public User(string name, string email, byte[] password, byte[] salt)
            => (Name, Email, Password, Salt) = (name, email, password, salt);

        public string Name { get; }

        public string Email { get; }

        public byte[]? Password { get; }

        public byte[]? Salt { get; }
    }
}