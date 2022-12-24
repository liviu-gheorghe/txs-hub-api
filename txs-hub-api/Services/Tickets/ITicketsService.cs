using Microsoft.AspNetCore.JsonPatch;
using txs_hub_api.Models;

namespace txs_hub_api.Services.Tickets
{
    public interface ITicketsService
    {

        Task<List<Ticket>> GetAll();

        Task<Ticket> Post(Ticket e);

        Task<Ticket> GetById(Guid id);

        Task<Ticket?> UpdateById(Guid id, Ticket e);

        Task<Ticket?> PartiallyUpdateById(Guid id, JsonPatchDocument<Ticket> e);

        Task<Ticket?> DeleteById(Guid id);

    }
}
