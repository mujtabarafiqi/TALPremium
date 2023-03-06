using TAL.Data.DTO;

namespace TAL.Data.Repository.Abstract
{
    public interface IMemberRepository
    {
        Task<PremiumDTO> GetMonthlyPremium(MemberDTO member);
    }
}
