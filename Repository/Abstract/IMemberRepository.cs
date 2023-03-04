using TALPremium.DTO;

namespace TALPremium.Repository.Abstract
{
    public interface IMemberRepository
    {
        Task<PremiumDTO> GetMonthlyPremium(MemberDTO member);
    }
}
