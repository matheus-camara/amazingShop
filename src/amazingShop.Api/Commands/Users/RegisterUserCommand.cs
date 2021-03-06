using amazingShop.Api.Dtos;
using amazingShop.Domain.Core.Commands;
using MediatR;

namespace amazingShop.Api.Commands.Users
{
    public sealed class RegisterUserCommand : Command, IRequest<RegisterUserCommand>
    {
        public string? Name { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public UserDto? Result { get; set; }
    }
}