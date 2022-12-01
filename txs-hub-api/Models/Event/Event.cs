﻿using txs_hub_api.Models.Base;

namespace txs_hub_api.Models.Event
{
    public class Event: BaseEntity
    {

        public string EventTitle { get; set; }

        public string? EventDescription { get; set; }

        // TODO: Add event labels / categories

        // TODO Add event organizer

        public string? EventImageURL { get; set; }
      
        public DateTime EventStartDateTime { get; set; }
        public DateTime? EventEndDateTime { get; set; }


    }
}
