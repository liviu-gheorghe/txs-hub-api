using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using txs_hub_api.Models;
using txs_hub_api.Models.DTOs;
using txs_hub_api.Services.Tickets;
using AutoMapper;
using txs_hub_api.Models.DTOs.Ticket;

namespace txs_hub_api.Controllers
{
    [Route("api/tickets")]
    [ApiController]
    //[Authorize]
    public class TicketsController : ControllerBase
    {

        public readonly ITicketsService ticketsService;

        public TicketsController(ITicketsService _ticketsService)
        {
            ticketsService = _ticketsService;
        }

        [HttpGet]
        public async Task<List<TicketResponseDTO>> GetAllTickets()
        {
            return await ticketsService.GetAll();
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateTicketRequestDTO e)
        {
            var createdResource = await ticketsService.Post(e);

            return Created("", createdResource);

        }

        [HttpGet("{id}")]
        public async Task<TicketResponseDTO> GetById([FromRoute] Guid id)
        {
            return await ticketsService.GetById(id);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById([FromRoute] Guid id)
        {
            var foundTicket = await ticketsService.DeleteById(id);
            if (foundTicket != null)
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }


        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateById([FromBody] UpdateTicketRequestDTO e, [FromRoute] Guid id)
        {
            if (id.Equals(null))
            {
                return BadRequest("You must provide the id of the entity");
            }

            if (id != e?.Id)
            {
                return BadRequest("The id provided in the path variables should match the one from the entity");
            }

            var updatedTicket = await ticketsService.UpdateById(id, e);
            if (updatedTicket != null)
            {
                return Ok(updatedTicket);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PartiallyUpdateById([FromRoute] Guid id, [FromBody] JsonPatchDocument<UpdateTicketRequestDTO> e)
        {
            if (id.Equals(null))
            {
                return BadRequest("You must provide the id of the entity");
            }

            var updatedTicket = await ticketsService.PartiallyUpdateById(id, e);
            if (updatedTicket != null)
            {
                return Ok(updatedTicket);
            }
            else
            {
                return NotFound();
            }
        }
    }
}