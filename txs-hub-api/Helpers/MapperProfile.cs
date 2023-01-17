using AutoMapper;
using txs_hub_api.Models.DTOs;
using txs_hub_api.Models;
using txs_hub_api.Models.DTOs.Ticket;
using txs_hub_api.Models.DTOs.Location;

namespace txs_hub_api.Helpers
{
    public class MapperProfile: Profile
    {
        public MapperProfile()
        {
            CreateMap<Ticket, TicketResponseDTO>();
            CreateMap<CreateTicketRequestDTO, Ticket>();
            CreateMap<UpdateTicketRequestDTO, Ticket>();
            CreateMap<Location, LocationResponseDTO>();
            CreateMap<CreateLocationRequestDTO, Location>();
            CreateMap<UpdateLocationRequestDTO, Location>();
        }
    }
}
