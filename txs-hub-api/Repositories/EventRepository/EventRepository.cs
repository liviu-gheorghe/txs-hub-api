using IdentityModel;
using Microsoft.EntityFrameworkCore;
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

        public override async Task<List<Event>> GetAllAsync()
        {
            var allItems = await _table.AsNoTracking().Include(x => x.Locations).ToListAsync();
            return allItems;
        }

        public IQueryable<Event> GetAllAsQueryable()
        {
            return _table.Include(x => x.Locations).AsQueryable();
        }

        public override async Task<Event> FindByIdAsync(object id)
        {
            return await this._context.Events.Include(x => x.Locations).FirstOrDefaultAsync(e => e.Id == (Guid) id);
        }

    }
}

