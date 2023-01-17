using txs_hub_api.Data;
using txs_hub_api.Models;
using txs_hub_api.Repositories.EventRepository;
using txs_hub_api.Repositories.GenericRepository;

namespace txs_hub_api.Repositories.LocationRepository
{
    public class LocationRepository : GenericRepository<Location>, ILocationRepository
    {

        public LocationRepository(DatabaseContext _dbContext) : base(_dbContext)
        {
        }
    }
}

