using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using txs_hub_api.Data;
using txs_hub_api.Models;
using txs_hub_api.Repositories.EventRepository;
using txs_hub_api.Repositories.TicketRepository;

namespace txs_hub_api.Services.Tickets
{
    public class TicketsService : ITicketsService
    {

        protected readonly ITicketRepository _ticketRepository;

        public TicketsService(ITicketRepository _ticketRepository)
        {
            this._ticketRepository = _ticketRepository;
        }

        public async Task<List<Ticket>> GetAll()
        {
            return await _ticketRepository.GetAllAsync();
        }


        public async Task<Ticket> Post(Ticket e)
        {
            var createdTicket = await _ticketRepository.CreateAsync(e);
            await _ticketRepository.SaveAsync();
            return createdTicket;
        }

        public async Task<Ticket> GetById(Guid id)
        {
            return await _ticketRepository.FindByIdAsync(id);
        }

        public async Task<Ticket?> UpdateById(Guid id, Ticket e)
        {
            var updatedTicket = _ticketRepository.Update(e);
            await _ticketRepository.SaveAsync();
            return updatedTicket;
        }

        public async Task<Ticket?> PartiallyUpdateById(Guid id, JsonPatchDocument<Ticket> e)
        {
            var updatedTicket = _ticketRepository.PartiallyUpdate(id, e);
            await _ticketRepository.SaveAsync();
            return updatedTicket;
        }

        public async Task<Ticket?> DeleteById(Guid id)
        {
            return _ticketRepository.DeleteById(id);
        }
    }
}
