using CQRS_Service.Application.UseCases.User.Commands;
using CQRS_Service.Application.UseCases.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace CQRS_Service.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllUser()
        {
            var result = await _mediator.Send(new GetAllUserQuery());
            return Ok(result);
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateAsync(CreateUserCommand command)
        {
            await _mediator.Send(command);
            return Ok("Created");
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetByIdUSer(int id)
        {
            var result = await _mediator.Send(new GetByIdUserQuery() { Id = id });
            return Ok(result);
        }
        [HttpPut]
        public async ValueTask<IActionResult> UpdateUserAsync(UpdateUserCommand command)
        {
            await _mediator.Send(command);
            return Ok("Updated");
        }
        [HttpDelete]
        public async ValueTask<IActionResult> DeleteUserAsync(int id)
        {
            await _mediator.Send(new DeleteUserCommand() { Id = id });
            return Ok("Deleted");
        }

    }
}
