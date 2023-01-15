using Microsoft.AspNetCore.JsonPatch;
using txs_hub_api.Models;
using txs_hub_api.Models.DTOs;
using txs_hub_api.Models.DTOs.Ticket;

namespace txs_hub_api.Services.Tickets
{
    public interface ITicketsService
    {

        Task<List<TicketResponseDTO>> GetAll();

        Task<TicketResponseDTO> Post(CreateTicketRequestDTO e);

        Task<TicketResponseDTO> GetById(Guid id);

        Task<TicketResponseDTO?> UpdateById(Guid id, UpdateTicketRequestDTO e);

        Task<TicketResponseDTO?> PartiallyUpdateById(Guid id, JsonPatchDocument<UpdateTicketRequestDTO> e);

        Task<TicketResponseDTO?> DeleteById(Guid id);

    }
}
