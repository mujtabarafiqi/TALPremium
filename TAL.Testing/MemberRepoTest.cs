using Microsoft.EntityFrameworkCore;
using TAL.Data.Enums;
using TAL.Data.Repository.Concrete;
using TAL.Data.Repository.Context;

namespace TAL.Testing
{
    public class MemberRepoTest
    {
        protected readonly TALDbContext _context;
        public MemberRepoTest()
        {
            var options = new DbContextOptionsBuilder<TALDbContext>()
        .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
        .Options;

            _context = new TALDbContext(options);

            DbInitializer.Initialize(_context);
        }

        [Fact]
        public async Task IsMonthlyPremiumCorrectlyCalculated()
        {
            var member = new Data.DTO.MemberDTO()
            {
                Age = 50,
                OccupationId = await _context.Occupations.Where(x => x.Name == OccupationNames.Farmer).Select(x => x.Id).FirstOrDefaultAsync(),
                SumInsured = 100
            };

            MemberRepository repo = new MemberRepository(_context);
            var premium = await repo.GetMonthlyPremium(member);
            //Death Premium = (Sum Insured * Occupation Rating Factor * Age) /1000 * 12
            var deathPremium = member.SumInsured * RatingFactors.HeavyManual * member.Age / 1000 * 12;
            Assert.Equal(deathPremium, premium.DeathPremium);
            //TPD Premium Monthly = (Sum Insured * Occupation Rating Factor * Age) /1234
            var monthlyPremium = member.SumInsured* RatingFactors.HeavyManual* member.Age / 1234;
            Assert.Equal(monthlyPremium, premium.TPDMonthlyPremium);
        }
    }
}
