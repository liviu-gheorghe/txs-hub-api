using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using txs_hub_api.Data;
using txs_hub_api.Models;
using txs_hub_api.Models.DTOs;
using txs_hub_api.Models.DTOs.Ticket;
using txs_hub_api.Repositories.EventRepository;
using txs_hub_api.Repositories.TicketRepository;

namespace txs_hub_api.Services.Tickets
{
    public class TicketsService : ITicketsService
    {

        protected readonly ITicketRepository _ticketRepository;

        protected IMapper _mapper;

        public TicketsService(ITicketRepository _ticketRepository, IMapper _mapper)
        {
            this._ticketRepository = _ticketRepository;
            this._mapper = _mapper;
        }

        public async Task<List<TicketResponseDTO>> GetAll()
        {
            var tickets = await _ticketRepository.GetAllAsync();
            return _mapper.Map<List<TicketResponseDTO>>(tickets);
        }

        public async Task<TicketResponseDTO> Post(CreateTicketRequestDTO e)
        {

            var ticketToBeCreated = _mapper.Map<Ticket>(e);
            var createdTicket = await _ticketRepository.CreateAsync(ticketToBeCreated);
            await _ticketRepository.SaveAsync();
            return _mapper.Map<TicketResponseDTO>(createdTicket);
        }

        public async Task<TicketResponseDTO> GetById(Guid id)
        {
            var foundTicket = await _ticketRepository.FindByIdAsync(id);
            return _mapper.Map<TicketResponseDTO>(foundTicket);
        }

        public async Task<TicketResponseDTO?> UpdateById(Guid id, UpdateTicketRequestDTO e)
        {
            var updatedTicket = _ticketRepository.Update(_mapper.Map<Ticket>(e));
            await _ticketRepository.SaveAsync();
            return _mapper.Map<TicketResponseDTO>(updatedTicket);
        }

        public async Task<TicketResponseDTO?> PartiallyUpdateById(Guid id, JsonPatchDocument<UpdateTicketRequestDTO> e)
        {
            var updatedTicket = _ticketRepository.PartiallyUpdate(id, _mapper.Map<JsonPatchDocument<Ticket>>(e));
            await _ticketRepository.SaveAsync();
            return _mapper.Map<TicketResponseDTO>(updatedTicket);
        }

        public async Task<TicketResponseDTO?> DeleteById(Guid id)
        {
            var deletedTicket = _ticketRepository.DeleteById(id);
            return _mapper.Map<TicketResponseDTO>(deletedTicket);
        }
    }
}
