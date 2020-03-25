using amazingShop.Api.Dtos;
using amazingShop.Domain.Core.Commands;
using MediatR;

namespace amazingShop.Api.Commands.Users
{
    public sealed class RegisterUserCommand : Command, IRequest<RegisterUserCommand>
    {
        public string? Name { get; }

        public string? Email { get; }

        public string? Password { get; }

        public UserDto? Result { get; set; }
    }
}