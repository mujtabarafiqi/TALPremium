using Microsoft.EntityFrameworkCore;
using TAL.Data.DTO;
using TAL.Data.Repository.Abstract;
using TAL.Data.Repository.Context;

namespace TAL.Data.Repository.Concrete
{
    public class OccupationRepository : IOccupationRepository
    {

        private readonly TALDbContext _dbContext;
        public OccupationRepository(TALDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<OccupationDTO>> GetAllOccupationsAsync()
        {
            return await _dbContext.Occupations
                .Where(x => !x.IsDeleted)
                .Select(x => new OccupationDTO()
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToListAsync();
        }
    }
}
