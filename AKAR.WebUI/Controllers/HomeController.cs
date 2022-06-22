using Microsoft.AspNetCore.Mvc;

namespace AKAR.WebUI.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
