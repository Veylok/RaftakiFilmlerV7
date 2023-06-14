
using Microsoft.AspNetCore.Mvc;
using ServicesV7.DBModels;
using ServicesV7.ViewModels;

namespace RaftakiFilmlerV7.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            
            UserVM _userVM = new UserVM();

            return View(_userVM);
        }
        [HttpPost]
        public IActionResult Index(UserVM _userVM)
        {
            FilmlerContext _filmlerContext = new FilmlerContext();
            var user = _filmlerContext.Users.FirstOrDefault(m => m.Name == _userVM.Name && m.Password == _userVM.Password);

            if (user == null)
            {
                TempData["ErrorMessage"] = "Giriş Bilgileri Yanlış";
               
                return View(_userVM);
            }
            else
            {
                HttpContext.Session.SetString("UserSession", "1");
                return RedirectToAction("Index", "Film");
            }
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear(); 
            return RedirectToAction("Index", "Home"); 
        }

    }
}



