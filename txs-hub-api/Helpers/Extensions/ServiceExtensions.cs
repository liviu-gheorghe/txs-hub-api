using txs_hub_api.Repositories.EventRepository;
using txs_hub_api.Services.Events;

namespace txs_hub_api.Helpers.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IEventRepository, EventRepository>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IEventsService, EventsService>();

            return services;
        }
    }
}
