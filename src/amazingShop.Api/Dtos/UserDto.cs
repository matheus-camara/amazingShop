namespace amazingShop.Api.Dtos
{
    public class UserDto
    {
        public string Name { get; } = default!;

        public string Email { get; set; } = default!;

        public UserDto(string name, string email)
        {
            Name = name;
            Email = email;
        }
    }
}