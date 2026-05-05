using BoardGameClub.Infrastructure.Persistence;
using BoardGameClub.Infrastructure.Persistence.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BoardGameClub.Api.Controllers
{
    [Route("api/member")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlServer("Server=localhost;Database=fbgcdb;Trusted_Connection=True;TrustServerCertificate=True;")
                .Options;

            using var context = new AppDbContext(options);

            var canConnect = await context.Database.CanConnectAsync();

            var data = await context.members.Where(x => x.id == 1).FirstOrDefaultAsync();

            return Ok(new
            {
                data
            });
        }
    }
}
