using txs_hub_api.Models.DTOs.Base;

namespace txs_hub_api.Models.DTOs.Ticket
{
    public class ITicketRequestDTO : BaseRequestDTO
    {
        public double TicketPrice { get; set; }
        public string? TicketDetails { get; set; }
        public string? TicketCategory { get; set; }
        public string CustomerId { get; set; } = string.Empty;
        public Guid EventId { get; set; }
        public DateTime PurchaseDateTime { get; set; }
    }
}