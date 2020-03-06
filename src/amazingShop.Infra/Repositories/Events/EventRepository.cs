using amazingShop.Domain.Core.Events;
using amazingShop.Domain.Repositories;

namespace amazingShop.Infra.Repositories.Events
{
    public sealed class EventRepository : Repository<ShopContext, Event>, IRepository<Event>
    {
        public EventRepository(ShopContext context) : base(context)
        {
        }
    }
}