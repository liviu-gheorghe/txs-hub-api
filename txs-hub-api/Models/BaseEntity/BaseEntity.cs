using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace txs_hub_api.Models.Base
{
    public class BaseEntity : IBaseEntity
    {



        public BaseEntity(): base()
        {
            DateCreated = DateTime.Now;
            DateModified = DateTime.Now;
        }


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
    }
}
