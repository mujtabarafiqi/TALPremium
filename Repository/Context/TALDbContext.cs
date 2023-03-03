using Microsoft.EntityFrameworkCore;
using TALPremium.Models;

namespace TALPremium.Repository.Context
{
    public class TALDbContext : DbContext
    {
        public TALDbContext(DbContextOptions<TALDbContext> options) : base(options) { }

        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Occupation> Occupations { get; set; }
        public DbSet<Member> Members { get; set; }

    }
}
