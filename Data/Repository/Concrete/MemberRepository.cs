using Microsoft.EntityFrameworkCore;
using TAL.Data.DTO;
using TAL.Data.Repository.Abstract;
using TAL.Data.Repository.Context;

namespace TAL.Data.Repository.Concrete
{
    public class MemberRepository : IMemberRepository
    {


        private readonly TALDbContext _dbContext;
        public MemberRepository(TALDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<PremiumDTO> GetMonthlyPremium(MemberDTO member)
        {
            // Get rating factor for the corresponding occupation
            var ratingFactor = await _dbContext.Occupations.Include(x => x.Rating).Where(x => x.Id == member.OccupationId).Select(x => x.Rating.Factor).FirstOrDefaultAsync();
            return new PremiumDTO()
            {
                //Death Premium = (Sum Insured * Occupation Rating Factor * Age) /1000 * 12
                DeathPremium = (member.SumInsured * ratingFactor * member.Age) / 1000 * 12,
                //TPD Premium Monthly = (Sum Insured * Occupation Rating Factor * Age) /1234
                TPDMonthlyPremium = member.SumInsured * ratingFactor * member.Age / 1234

            };

        }
    }
}
