using Microsoft.AspNetCore.JsonPatch;
using txs_hub_api.Models.Event;

namespace txs_hub_api.Services.Events
{
    public interface IEventsService
    {

        Task<List<Event>> GetAll();

        Task<Event> Post(Event e);

        Task<Event> GetById(Guid id);

        Task<Event?> UpdateById(Guid id, Event e);

        Task<Event?> PartiallyUpdateById(Guid id, JsonPatchDocument<Event> e);

        Task<Event?> DeleteById(Guid id);

    }
}
