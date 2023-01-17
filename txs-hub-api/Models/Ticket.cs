using System.ComponentModel.DataAnnotations.Schema;
using txs_hub_api.Models.Base;

namespace txs_hub_api.Models
{
    public class Ticket : BaseEntity
    {

        public double TicketPrice { get; set; }

        public string? TicketDetails { get; set; }
        public string? TicketCategory { get; set; }

        public ApplicationUser Customer { get; set; }
        public string CustomerId { get; set; }

        public Event Event { get; set; }
        public Guid EventId { get; set; }

        public DateTime PurchaseDateTime { get; set; }

    }
}
