using System.ComponentModel.DataAnnotations.Schema;

namespace TALPremium.Models
{
    public class Occupation : BaseEntity
    {
        public long RatingId { get; set; }

        [ForeignKey(nameof(RatingId))]
        public virtual Rating Rating { get; set; }


        [InverseProperty(nameof(Member.Occupation))]
        public ICollection<Member> Members { get; set; }
    }
}
