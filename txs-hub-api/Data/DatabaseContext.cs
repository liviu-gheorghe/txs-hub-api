using txs_hub_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.Extensions.Options;

namespace txs_hub_api.Data
{
    public class DatabaseContext: ApiAuthorizationDbContext<ApplicationUser>
    {
        // tables

        public DbSet<Event> Events { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options, IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

