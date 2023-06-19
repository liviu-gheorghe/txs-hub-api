using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using txs_hub_api.Models;
using txs_hub_api.Models.DTOs.Location;
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


        // Get All events from the repository

        public async Task<List<Event>> GetAll()
        {

            var events = _eventRepository.GetAllAsQueryable();


            // Get the search query from the query params of the http request and filter the 
            // events by the search query (the search query must be contained by the event title or
            // the event description) 


            string searchQuery = _httpContextAccessor.HttpContext.Request.Query["search"];

            if(!String.IsNullOrEmpty(searchQuery))
            {
                events = events.Where(x => x.EventTitle.ToLower().Contains(searchQuery.ToLower()) || x.EventDescription.ToLower().Contains(searchQuery.ToLower()));
            }

            // After the events have been filtered by the search query, return the result as a list of events

            return events.ToList();

        }



        // Create Events
        public async Task<Event> Post(Event e)
        {
            var createdEvent = await _eventRepository.CreateAsync(e);
            await _eventRepository.SaveAsync();
            return createdEvent;
        }

        // Get Event By Id
        public async Task<Event> GetById(Guid id)
        {
            return await _eventRepository.FindByIdAsync(id);
        }

        // Update Event By Id
        public async Task<Event?> UpdateById(Guid id, Event e) 
        {
            var updatedEvent = _eventRepository.Update(e);
            await _eventRepository.SaveAsync();
            return updatedEvent;
        }


        // Partially Update Event By Id
        
        public async Task<Event?> PartiallyUpdateById(Guid id, JsonPatchDocument<Event> e)
        {
            var updatedEvent = _eventRepository.PartiallyUpdate(id, e);
            await _eventRepository.SaveAsync();
            return updatedEvent;
        }


        // Delete Event By Id
        public async Task<Event?> DeleteById(Guid id)
        {
            return _eventRepository.DeleteById(id);
        }


        // Map existing locations to event locations
        public async Task<List<LocationResponseDTO>> PostEventLocation(Guid eventId, List<Guid> locationIds)
        {

            // Find the event to be updated using the eventId
            var eventToBeUpdated = await _eventRepository.FindByIdAsync(eventId);

           
            var locations = new List<LocationResponseDTO>();


            // For each locationId that should pe mapped as a event location for the current event, 
            // find the currentLocation using the LocationRepository and update the locations \
            // for the current eventToBeUpdated
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
