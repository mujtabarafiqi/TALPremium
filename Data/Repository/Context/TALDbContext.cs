using Microsoft.EntityFrameworkCore;
using TAL.Data.Models;

namespace TAL.Data.Repository.Context
{
    public class TALDbContext : DbContext
    {
        public TALDbContext(DbContextOptions<TALDbContext> options) : base(options) { }

        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Occupation> Occupations { get; set; }
        public DbSet<Member> Members { get; set; }

    }
}
