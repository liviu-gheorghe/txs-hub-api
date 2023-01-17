using Microsoft.AspNetCore.JsonPatch;
using txs_hub_api.Models;
using txs_hub_api.Models.DTOs;
using txs_hub_api.Models.DTOs.Location;

namespace txs_hub_api.Services.Locations
{
    public interface ILocationsService
    {

        Task<List<LocationResponseDTO>> GetAll();

        Task<LocationResponseDTO> Post(CreateLocationRequestDTO e);

        Task<LocationResponseDTO> GetById(Guid id);

        Task<LocationResponseDTO?> UpdateById(Guid id, UpdateLocationRequestDTO e);

        Task<LocationResponseDTO?> PartiallyUpdateById(Guid id, JsonPatchDocument<UpdateLocationRequestDTO> e);

        Task<LocationResponseDTO?> DeleteById(Guid id);

    }
}
