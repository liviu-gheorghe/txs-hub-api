using txs_hub_api.Data;
using txs_hub_api.Models;
using txs_hub_api.Repositories.EventRepository;
using txs_hub_api.Repositories.GenericRepository;

namespace txs_hub_api.Repositories.TicketRepository
{
    public class TicketRepository : GenericRepository<Ticket>, ITicketRepository
    {

        public TicketRepository(DatabaseContext _dbContext) : base(_dbContext)
        {
        }
    }
}

