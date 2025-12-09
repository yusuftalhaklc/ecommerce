using MediatR;
using Microsoft.AspNetCore.Mvc;
using ecommerce.Application.DTOs.AppUserProfileDTOs.Commands;
using ecommerce.Application.DTOs.AppUserProfileDTOs.Queries;

namespace ecommerce.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppUserProfilesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AppUserProfilesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllAppUserProfilesQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetAppUserProfileByIdQuery { Id = id });
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAppUserProfileCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateAppUserProfileCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteAppUserProfileCommand { Id = id });
            if (!result)
                return NotFound();
            return NoContent();
        }
    }
}

