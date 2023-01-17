using txs_hub_api.Repositories.EventRepository;
using txs_hub_api.Repositories.TicketRepository;
using txs_hub_api.Repositories.LocationRepository;
using txs_hub_api.Services.Events;
using txs_hub_api.Services.Tickets;
using txs_hub_api.Services.Locations;

namespace txs_hub_api.Helpers.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IEventRepository, EventRepository>();
            services.AddTransient<ITicketRepository, TicketRepository>();
            services.AddTransient<ILocationRepository, LocationRepository>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IEventsService, EventsService>();
            services.AddTransient<ITicketsService, TicketsService>();
            services.AddTransient<ILocationsService, LocationsService>();

            return services;
        }
    }
}
