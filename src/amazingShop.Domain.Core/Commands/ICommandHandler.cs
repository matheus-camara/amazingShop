using MediatR;

namespace amazingShop.Domain.Core.Commands
{
    public interface ICommandHandler<T> : IRequestHandler<T, T> where T : IRequest<T>
    {

    }
}