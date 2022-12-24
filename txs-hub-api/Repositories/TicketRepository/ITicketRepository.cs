using txs_hub_api.Models;
using txs_hub_api.Repositories.GenericRepository;

namespace txs_hub_api.Repositories.EventRepository
{
    public interface ITicketRepository : IGenericRepository<Ticket>
    {
    }
}
