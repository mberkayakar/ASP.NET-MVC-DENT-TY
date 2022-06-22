using Microsoft.AspNetCore.Mvc;

namespace AKAR.WebUI.ViewComponents
{
    public class NavbarViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
