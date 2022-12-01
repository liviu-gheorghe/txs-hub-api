using txs_hub_api.Models.Event;
using txs_hub_api.Repositories.GenericRepository;

namespace txs_hub_api.Repositories.EventRepository
{
    public interface IEventRepository : IGenericRepository<Event>
    {
    }
}
