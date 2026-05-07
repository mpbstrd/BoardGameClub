using BoardGameClub.Application.Features.Members.GetMemberById;
using BoardGameClub.Application.Features.Members.GetMembers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BoardGameClub.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MemberController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MemberController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetMembers()
        {
            var result = await _mediator.Send(new GetMembersQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMemberById(Guid id)
        {
            var result = await _mediator.Send(new GetMemberByIdQuery
            {
                Id = id
            });

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}