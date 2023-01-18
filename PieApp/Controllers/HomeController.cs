using Microsoft.AspNetCore.Mvc;
using PieApp.Models;
using PieApp.ViewModels;

namespace PieApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPieRepository _pieRepository;

        public HomeController(IPieRepository pieRepository)
        {
            _pieRepository = pieRepository;
        }

        public IActionResult Index()
        {
            var pieOfTheWeek = _pieRepository.PiesOfTheWeek;
            var homeViewModel = new HomeViewModel(pieOfTheWeek);
            return View(homeViewModel);
        }
    }
}
