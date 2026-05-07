using BoardGameClub.Infrastructure.Persistence;
using BoardGameClub.Infrastructure.Persistence.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BoardGameClub.Api.Controllers
{
    [Route("api/member")]
    [ApiController]
    public class MemberController(AppDbContext context) : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await context.members.ToListAsync();

            return Ok(new
            {
                data
            });
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(member member)
        {
            context.members.Add(member);
            await context.SaveChangesAsync();
            return Ok(new
            {
                data = member
            });
        }
    }
}
