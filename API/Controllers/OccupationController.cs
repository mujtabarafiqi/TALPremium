using Microsoft.AspNetCore.Mvc;
using TAL.Data.Repository.Abstract;

namespace TAL.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OccupationController : ControllerBase
    {
        private readonly IOccupationRepository _occupationRepository;
        public OccupationController(IOccupationRepository occupationRepository)
        {
            _occupationRepository = occupationRepository;
        }

        [HttpGet("GetAllOccupations")]
        public async Task<IActionResult> GetAllOccupationsAsync()
        {
            return Ok(await _occupationRepository.GetAllOccupationsAsync());
        }
    }
}
