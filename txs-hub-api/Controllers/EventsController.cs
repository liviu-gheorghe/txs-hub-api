using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using txs_hub_api.Models.Event;
using txs_hub_api.Services.Events;

namespace txs_hub_api.Controllers
{
    [Route("api/events")]
    [ApiController]
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
        public async Task<IActionResult> Post(Event e)
        {
            await eventsService.Post(e);

            return Ok();

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
    }
}