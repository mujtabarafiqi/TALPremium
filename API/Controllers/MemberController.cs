using Microsoft.AspNetCore.Mvc;
using TALPremium.DTO;
using TALPremium.Repository.Abstract;

namespace TALPremium.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IMemberRepository _memberRepository;

        public MemberController(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> GetPremium([FromBody] MemberDTO member)
        {
            return Ok(await _memberRepository.GetMonthlyPremium(member));
        }
    }
}
