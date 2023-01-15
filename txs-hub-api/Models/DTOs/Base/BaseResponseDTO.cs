namespace txs_hub_api.Models.DTOs.Base
{
    public class BaseResponseDTO
    {
        public Guid Id { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
    }
}
