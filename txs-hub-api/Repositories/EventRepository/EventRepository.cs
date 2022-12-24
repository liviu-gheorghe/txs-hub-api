using txs_hub_api.Data;
using txs_hub_api.Models;
using txs_hub_api.Repositories.GenericRepository;

namespace txs_hub_api.Repositories.EventRepository
{
    public class EventRepository: GenericRepository<Event>, IEventRepository
    {

        public EventRepository(DatabaseContext _dbContext): base(_dbContext)
        {
        }
    }
}

