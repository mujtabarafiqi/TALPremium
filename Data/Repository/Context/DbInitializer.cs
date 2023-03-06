using TAL.Data.Enums;
using TAL.Data.Models;

namespace TAL.Data.Repository.Context
{
    public class DbInitializer
    {
        public static void Initialize(TALDbContext context)
        {

            context.Database.EnsureCreated();
            if (!context.Ratings.Any(x => !x.IsDeleted))
            {
                var createdDate = DateTime.UtcNow;
                var ratings = new List<Rating>() {
                    new Rating()
                    {
                        Name = RatingNames.Professional,
                        Factor = RatingFactors.Professional,
                        Occupations = new List<Occupation>()
                        {
                            new Occupation()
                            {
                                Name = OccupationNames.Doctor,
                                CreatedOn = createdDate
                            }
                        },
                        CreatedOn = createdDate
                    },
                    new Rating()
                    {
                        Name = RatingNames.WhiteCollar,
                        Factor = RatingFactors.WhiteCollar,
                        Occupations = new List<Occupation>()
                        {
                            new Occupation()
                            {
                                Name = OccupationNames.Author,
                                CreatedOn = createdDate
                            }
                        },
                        CreatedOn = createdDate
                    },
                    new Rating()
                    {
                        Name = RatingNames.LightManual,
                        Factor = RatingFactors.LightManual,
                        Occupations = new List<Occupation>()
                        {
                            new Occupation()
                            {
                                Name = OccupationNames.Cleaner,
                                CreatedOn = createdDate
                            },
                            new Occupation()
                            {
                                Name = OccupationNames.Florist,
                                CreatedOn = createdDate
                            }
                        },
                        CreatedOn = createdDate
                    },
                    new Rating()
                    {
                        Name = RatingNames.HeavyManual,
                        Factor = RatingFactors.HeavyManual,
                        Occupations = new List<Occupation>()
                        {
                            new Occupation()
                            {
                                Name = OccupationNames.Farmer,
                                CreatedOn = createdDate
                            },
                            new Occupation()
                            {
                                Name = OccupationNames.Mechanic,
                                CreatedOn = createdDate
                            }
                        },
                        CreatedOn = createdDate
                    }
                };
                context.Ratings.AddRange(ratings);
                context.SaveChanges();
            }
        }
    }
}
