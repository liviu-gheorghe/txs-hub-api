using Microsoft.AspNetCore.JsonPatch;
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


        public async Task<Event> Post(Event e)
        {
            var createdEvent = await _eventRepository.CreateAsync(e);
            await _eventRepository.SaveAsync();
            return createdEvent;
        }

        public async Task<Event> GetById(Guid id)
        {
            return await _eventRepository.FindByIdAsync(id);
        }

        public async Task<Event?> UpdateById(Guid id, Event e) 
        {
            var updatedEvent = _eventRepository.Update(e);
            await _eventRepository.SaveAsync();
            return updatedEvent;
        }

        public async Task<Event?> PartiallyUpdateById(Guid id, JsonPatchDocument<Event> e)
        {
            var updatedEvent = _eventRepository.PartiallyUpdate(id, e);
            await _eventRepository.SaveAsync();
            return updatedEvent;
        }

        public async Task<Event?> DeleteById(Guid id)
        {
            return _eventRepository.DeleteById(id);
        }
    }
}
