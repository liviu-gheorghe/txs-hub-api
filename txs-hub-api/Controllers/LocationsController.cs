using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using txs_hub_api.Models;
using txs_hub_api.Models.DTOs;
using txs_hub_api.Services.Locations;
using AutoMapper;
using txs_hub_api.Models.DTOs.Location;

namespace txs_hub_api.Controllers
{
    [Route("api/locations")]
    [ApiController]
    //[Authorize]
    public class LocationsController : ControllerBase
    {

        public readonly ILocationsService LocationsService;

        public LocationsController(ILocationsService _LocationsService)
        {
            LocationsService = _LocationsService;
        }

        [HttpGet]
        public async Task<List<LocationResponseDTO>> GetAllLocations()
        {
            return await LocationsService.GetAll();
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateLocationRequestDTO e)
        {
            var createdResource = await LocationsService.Post(e);

            return Created("", createdResource);

        }

        [HttpGet("{id}")]
        public async Task<LocationResponseDTO> GetById([FromRoute] Guid id)
        {
            return await LocationsService.GetById(id);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById([FromRoute] Guid id)
        {
            var foundLocation = await LocationsService.DeleteById(id);
            if (foundLocation != null)
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }


        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateById([FromBody] UpdateLocationRequestDTO e, [FromRoute] Guid id)
        {
            if (id.Equals(null))
            {
                return BadRequest("You must provide the id of the entity");
            }

            if (id != e?.Id)
            {
                return BadRequest("The id provided in the path variables should match the one from the entity");
            }

            var updatedLocation = await LocationsService.UpdateById(id, e);
            if (updatedLocation != null)
            {
                return Ok(updatedLocation);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PartiallyUpdateById([FromRoute] Guid id, [FromBody] JsonPatchDocument<UpdateLocationRequestDTO> e)
        {
            if (id.Equals(null))
            {
                return BadRequest("You must provide the id of the entity");
            }

            var updatedLocation = await LocationsService.PartiallyUpdateById(id, e);
            if (updatedLocation != null)
            {
                return Ok(updatedLocation);
            }
            else
            {
                return NotFound();
            }
        }
    }
}