using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly IHttpContextAccessor _httpContextAccessor;

        public EventsService(IEventRepository _eventRepository, ILocationRepository _locationRepository, IMapper _mapper, IHttpContextAccessor httpContextAccessor)
        {
            this._eventRepository = _eventRepository;
            this._locationRepository = _locationRepository;
            this._mapper = _mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<Event>> GetAll()
        {

            var events = _eventRepository.GetAllAsQueryable();


            string searchQuery = _httpContextAccessor.HttpContext.Request.Query["search"];

            if(!String.IsNullOrEmpty(searchQuery))
            {
                events = events.Where(x => x.EventTitle.ToLower().Contains(searchQuery.ToLower()) || x.EventDescription.ToLower().Contains(searchQuery.ToLower()));
            }

            return events.ToList();

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
