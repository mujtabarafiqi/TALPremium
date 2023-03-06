using System.ComponentModel.DataAnnotations.Schema;

namespace TAL.Data.Models
{
    public class Member : BaseEntity
    {
        public DateTime DateOfBirth { get; set; }
        public decimal Age { get; set; }
        public decimal SumInsured { get; set; }

        public long OccupationId { get; set; }
        [ForeignKey(nameof(OccupationId))]
        public virtual Occupation Occupation { get; set; }
    }
}
