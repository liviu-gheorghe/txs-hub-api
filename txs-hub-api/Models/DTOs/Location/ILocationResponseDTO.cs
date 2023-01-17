using System.ComponentModel.DataAnnotations;
using txs_hub_api.Models.DTOs.Base;

namespace txs_hub_api.Models.DTOs.Location
{

    public class ILocationResponseDTO : BaseResponseDTO
    {

        public string Country { get; set; }
        public string? Region { get; set; }
        public string? County { get; set; }
        public string? City { get; set; }
        public string? ZipCode { get; set; }
        public string? Address { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public ICollection<Event>? Events { get; set; }

    }
}