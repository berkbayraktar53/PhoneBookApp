using Microsoft.AspNetCore.Mvc;

namespace PhoneBookApp.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}