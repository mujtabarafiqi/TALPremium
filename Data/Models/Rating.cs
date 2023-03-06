using System.ComponentModel.DataAnnotations.Schema;

namespace TAL.Data.Models
{
    public class Rating : BaseEntity
    {
        public decimal Factor { get; set; }

        [InverseProperty(nameof(Occupation.Rating))]
        public ICollection<Occupation> Occupations { get; set; }
    }
}
