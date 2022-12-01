using txs_hub_api.Models.Event;

namespace txs_hub_api.Services.Events
{
    public interface IEventsService
    {

        Task<List<Event>> GetAll();

        Task Post(Event e);

        Task<Event> GetById(Guid id);

        Task<Event?> DeleteById(Guid id);

    }
}
