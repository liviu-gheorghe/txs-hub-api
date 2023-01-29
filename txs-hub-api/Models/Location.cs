using System.ComponentModel.DataAnnotations;
using txs_hub_api.Models.Base;

namespace txs_hub_api.Models
{
    public class Location: BaseEntity
    {
        public string Country { get; set; }
        public string? Region { get; set; }
        public string? County { get; set; }
        public string? City { get; set; }
        public string? ZipCode { get; set; }
        public string? Address { get; set; }
        [Range(-90, 90)]
        public decimal? Latitude { get; set; }
        [Range(-180, 180)]
        public decimal? Longitude { get; set; }
        public ICollection<Event>? Events { get; set; } = new List<Event>();
    }
}
