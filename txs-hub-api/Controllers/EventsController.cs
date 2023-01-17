using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using txs_hub_api.Models;
using txs_hub_api.Models.DTOs.Location;
using txs_hub_api.Services.Events;

namespace txs_hub_api.Controllers
{
    [Route("api/events")]
    [ApiController]
    //[Authorize]
    public class EventsController : ControllerBase
    {

        public readonly IEventsService eventsService;

        public EventsController(IEventsService _eventsService)
        {
            eventsService = _eventsService;
        }

        [HttpGet]
        public async Task<List<Event>> GetAllEvents()
        {
            return await eventsService.GetAll();
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Event e)
        {
            var createdResource = await eventsService.Post(e);

            return Created("", createdResource);

        }

        [HttpPost("{id}/locations/")]
        public async Task<IActionResult> PostEventLocation([FromBody] List<Guid> locationIds)
        {

            var eventId = HttpContext.Request.RouteValues["id"].ToString();
            var createdResource = await eventsService.PostEventLocation(Guid.Parse(eventId), locationIds);

            return Created("", createdResource);

        }

        [HttpGet("{id}")]
        public async Task<Event> GetById([FromRoute] Guid id)
        {
            return await eventsService.GetById(id);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById([FromRoute] Guid id)
        {
             var foundEvent = await eventsService.DeleteById(id);
            if(foundEvent != null)
            {
                return NoContent();
            } else
            {
                return NotFound();
            }
        }


        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateById([FromBody] Event e, [FromRoute] Guid id)
        {
            if(id.Equals(null))
            {
                return BadRequest("You must provide the id of the entity");
            }

            if(id != e?.Id)
            {
                return BadRequest("The id provided in the path variables should match the one from the entity");
            }

            var updatedEvent = await eventsService.UpdateById(id, e);
            if (updatedEvent != null)
            {
                return Ok(updatedEvent);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PartiallyUpdateById([FromRoute] Guid id, [FromBody] JsonPatchDocument<Event> e)
        {
            if (id.Equals(null))
            {
                return BadRequest("You must provide the id of the entity");
            }

            var updatedEvent = await eventsService.PartiallyUpdateById(id, e);
            if (updatedEvent != null)
            {
                return Ok(updatedEvent);
            }
            else
            {
                return NotFound();
            }
        }
    }
}