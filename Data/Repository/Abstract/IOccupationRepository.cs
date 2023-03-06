using TAL.Data.DTO;

namespace TAL.Data.Repository.Abstract
{
    public interface IOccupationRepository
    {
        Task<List<OccupationDTO>> GetAllOccupationsAsync();
    }
}
