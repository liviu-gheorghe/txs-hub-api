﻿using txs_hub_api.Models.Base;

namespace txs_hub_api.Models
{
    public class Ticket : BaseEntity
    {

        public double TicketPrice { get; set; }

        public string? TicketDetails { get; set; }
        public string? TicketCategory { get; set; }

        public ApplicationUser Customer { get; set; }

        public Event Event;

        public DateTime PurchaseDateTime { get; set; }

    }
}
