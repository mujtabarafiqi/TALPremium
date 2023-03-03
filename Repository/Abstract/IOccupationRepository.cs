using TALPremium.DTO;

namespace TALPremium.Repository.Abstract
{
    public interface IOccupationRepository
    {
        Task<List<OccupationDTO>> GetAllOccupationsAsync();
    }
}
