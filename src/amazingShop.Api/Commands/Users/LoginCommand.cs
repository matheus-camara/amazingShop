using amazingShop.Domain.Core.Commands;
using MediatR;

namespace amazingShop.Api.Commands.Users
{
    public sealed class LoginCommand : Command, IRequest<LoginCommand>
    {
        public string? Name { get; set; }

        public string? Password { get; set; }

        public string? Result { get; set; }
    }
}