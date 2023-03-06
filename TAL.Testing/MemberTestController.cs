using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TAL.API.Controllers;
using TAL.Data.Repository.Abstract;

namespace TAL.Testing
{
    public class MemberTestController
    {
        [Fact]
        public async Task GetMonthlyPremium_ShouldReturn200Status()
        {
            var member = new Data.DTO.MemberDTO()
            {
                Age = 50,
                OccupationId = 9,
                SumInsured = 100
            };
            /// Arrange
            var memberRepo = new Mock<IMemberRepository>();
            memberRepo.Setup(_ => _.GetMonthlyPremium(member)).ReturnsAsync(new Data.DTO.PremiumDTO()
            {
                DeathPremium = 0,
                TPDMonthlyPremium = 0
            });
            var controller = new MemberController(memberRepo.Object);

            /// Act
            var result = (OkObjectResult)await controller.GetPremium(member);


            // /// Assert
            result.StatusCode.Should().Be(200);

        }
    }
}