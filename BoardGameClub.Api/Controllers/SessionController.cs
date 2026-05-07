using Microsoft.AspNetCore.Mvc;

namespace BoardGameClub.Api.Controllers
{
    public class SessionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
