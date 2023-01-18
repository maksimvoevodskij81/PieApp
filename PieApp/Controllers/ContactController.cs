using Microsoft.AspNetCore.Mvc;

namespace PieApp.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
