using txs_hub_api.Models;
using Microsoft.EntityFrameworkCore;
using txs_hub_api.Models.Event;

namespace txs_hub_api.Data
{
    public class DatabaseContext: DbContext
    {
        // tables

        public DbSet<Event> Events { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

