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
                        Name = "Professional",
                        Factor = 1,
                        Occupations = new List<Occupation>()
                        {
                            new Occupation()
                            {
                                Name = "Doctor",
                                CreatedOn = createdDate
                            }
                        },
                        CreatedOn = createdDate
                    },
                    new Rating()
                    {
                        Name = "White Collar",
                        Factor = (decimal)1.25,
                        Occupations = new List<Occupation>()
                        {
                            new Occupation()
                            {
                                Name = "Author",
                                CreatedOn = createdDate
                            }
                        },
                        CreatedOn = createdDate
                    },
                    new Rating()
                    {
                        Name = "Light Manual",
                        Factor = (decimal)1.5,
                        Occupations = new List<Occupation>()
                        {
                            new Occupation()
                            {
                                Name = "Cleaner",
                                CreatedOn = createdDate
                            },
                            new Occupation()
                            {
                                Name = "Florist",
                                CreatedOn = createdDate
                            }
                        },
                        CreatedOn = createdDate
                    },
                    new Rating()
                    {
                        Name = "Heavy Manual",
                        Factor = (decimal)1.5,
                        Occupations = new List<Occupation>()
                        {
                            new Occupation()
                            {
                                Name = "Farmer",
                                CreatedOn = createdDate
                            },
                            new Occupation()
                            {
                                Name = "Mechanic",
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
