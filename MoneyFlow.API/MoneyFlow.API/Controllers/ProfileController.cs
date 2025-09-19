using MediatR;
using Microsoft.AspNetCore.Mvc;
using MoneyFlow.Api.DTO.UserProfile.Command;
using MoneyFlow.Application.Commands.User;
namespace MoneyFlow.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfileController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProfileController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create-user-profile")]
        public async Task<IActionResult> CreateUserProfile([FromBody] CreateUserProfileDTO dto)
        {
            var command = new CreateUserProfileCommand
            {
                UserName = dto.UserName,
            };


            var userProfileId = await _mediator.Send(command);
            return Ok(userProfileId);
        }
    }
}
