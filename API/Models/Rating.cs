using System.ComponentModel.DataAnnotations.Schema;

namespace TALPremium.Models
{
    public class Rating : BaseEntity
    {
        public decimal Factor { get; set; }

        [InverseProperty(nameof(Occupation.Rating))]
        public ICollection<Occupation> Occupations { get; set; }
    }
}
