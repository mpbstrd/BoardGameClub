using Microsoft.AspNetCore.Mvc;

namespace BoardGameClub.Api.Controllers
{
    public class MechanicsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
