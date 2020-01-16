using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace amazingShop.Domain.Core.Commands
{
    public interface ICommandHandler<T> where T : Command
    {
        Task<T> ExecuteAsync(T command);
    }
}
