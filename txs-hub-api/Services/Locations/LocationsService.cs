using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using txs_hub_api.Data;
using txs_hub_api.Models;
using txs_hub_api.Models.DTOs;
using txs_hub_api.Models.DTOs.Location;
using txs_hub_api.Repositories.EventRepository;
using txs_hub_api.Repositories.LocationRepository;

namespace txs_hub_api.Services.Locations
{
    public class LocationsService : ILocationsService
    {

        protected readonly ILocationRepository _LocationRepository;

        protected IMapper _mapper;

        public LocationsService(ILocationRepository _LocationRepository, IMapper _mapper)
        {
            this._LocationRepository = _LocationRepository;
            this._mapper = _mapper;
        }

        public async Task<List<LocationResponseDTO>> GetAll()
        {
            var Locations = await _LocationRepository.GetAllAsync();
            return _mapper.Map<List<LocationResponseDTO>>(Locations);
        }

        public async Task<LocationResponseDTO> Post(CreateLocationRequestDTO e)
        {

            var LocationToBeCreated = _mapper.Map<Location>(e);


            Console.WriteLine("Location to be created events");

            Console.WriteLine(LocationToBeCreated.Events.Count());

            var CreatedLocation = await _LocationRepository.CreateAsync(LocationToBeCreated);
            await _LocationRepository.SaveAsync();
            return _mapper.Map<LocationResponseDTO>(CreatedLocation);
        }

        public async Task<LocationResponseDTO> GetById(Guid id)
        {
            var foundLocation = await _LocationRepository.FindByIdAsync(id);
            return _mapper.Map<LocationResponseDTO>(foundLocation);
        }

        public async Task<LocationResponseDTO?> UpdateById(Guid id, UpdateLocationRequestDTO e)
        {
            var updatedLocation = _LocationRepository.Update(_mapper.Map<Location>(e));
            await _LocationRepository.SaveAsync();
            return _mapper.Map<LocationResponseDTO>(updatedLocation);
        }

        public async Task<LocationResponseDTO?> PartiallyUpdateById(Guid id, JsonPatchDocument<UpdateLocationRequestDTO> e)
        {
            var updatedLocation = _LocationRepository.PartiallyUpdate(id, _mapper.Map<JsonPatchDocument<Location>>(e));
            await _LocationRepository.SaveAsync();
            return _mapper.Map<LocationResponseDTO>(updatedLocation);
        }

        public async Task<LocationResponseDTO?> DeleteById(Guid id)
        {
            var deletedLocation = _LocationRepository.DeleteById(id);
            return _mapper.Map<LocationResponseDTO>(deletedLocation);
        }
    }
}
