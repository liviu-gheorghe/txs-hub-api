using Microsoft.AspNetCore.Mvc;
using txs_hub_api.Data;
using txs_hub_api.Models.Event;
using txs_hub_api.Repositories.EventRepository;

namespace txs_hub_api.Services.Events
{
    public class EventsService : IEventsService
    {

        protected readonly IEventRepository _eventRepository;
       
        public EventsService(IEventRepository _eventRepository)
        {
            this._eventRepository = _eventRepository;
        }

        public async Task<List<Event>> GetAll()
        {
            return await _eventRepository.GetAllAsync();
        }


        public async Task Post(Event e)
        {

            Console.Write(e);
            await _eventRepository.CreateAsync(e);
            await _eventRepository.SaveAsync();
        }

        public async Task<Event> GetById(Guid id)
        {
            return await _eventRepository.FindByIdAsync(id);
        }

        public async Task<Event?> DeleteById(Guid id)
        {
            return _eventRepository.DeleteById(id);
        }
    }
}
