using System.Threading.Tasks;

namespace amazingShop.Domain.Core.Commands
{
    public interface ICommandHandler<T> where T : Command
    {
        Task<T> ExecuteAsync(T command);
    }
}