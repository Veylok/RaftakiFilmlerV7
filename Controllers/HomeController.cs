using Microsoft.AspNetCore.Mvc;
using RaftakiFilmlerV7.Models;
using ServicesV7.Classes;
using System.Diagnostics;

namespace RaftakiFilmlerV7.Controllers
{
    public class HomeController : Controller
    {
        private FilmService filmService;

        public HomeController()
        {
            filmService = new FilmService();
        }

        public IActionResult Index()
        {
            return RedirectToAction("GetFilmData");
        }

        public IActionResult GetFilmData()
        {
            var vm = filmService.getFilmVMList();

            return View("Index", vm);
        }

        public IActionResult Privacy()
        {
            var vm = filmService.GetFilmsByCategory();
            return View(vm);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
