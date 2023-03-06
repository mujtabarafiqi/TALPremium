using Microsoft.AspNetCore.Mvc;
using TALPremium.Repository.Abstract;

namespace TALPremium.Controllers
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
