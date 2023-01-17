using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using txs_hub_api.Data;
using txs_hub_api.Models;
using txs_hub_api.Models.DTOs.Location;
using txs_hub_api.Models.DTOs.Ticket;
using txs_hub_api.Repositories.EventRepository;
using txs_hub_api.Repositories.LocationRepository;

namespace txs_hub_api.Services.Events
{
    public class EventsService : IEventsService
    {

        protected readonly IEventRepository _eventRepository;
        protected readonly ILocationRepository _locationRepository;
        protected IMapper _mapper;

        public EventsService(IEventRepository _eventRepository, ILocationRepository _locationRepository, IMapper _mapper)
        {
            this._eventRepository = _eventRepository;
            this._locationRepository = _locationRepository;
            this._mapper = _mapper;
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

        public async Task<List<LocationResponseDTO>> PostEventLocation(Guid eventId, List<Guid> locationIds)
        {

            var eventToBeUpdated = await _eventRepository.FindByIdAsync(eventId);

            var locations = new List<LocationResponseDTO>();

            foreach(var locationId in locationIds)
            {
                var currentLocation = await _locationRepository.FindByIdAsync(locationId);
                locations.Add(_mapper.Map<LocationResponseDTO>(currentLocation));
                eventToBeUpdated.Locations.Add(currentLocation);

            }

            _eventRepository.Update(eventToBeUpdated);

            await _eventRepository.SaveAsync();

            return locations;


        }
    }
}
