using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace RaftakiFilmlerV7.Controllers
{
    public class Base : Controller
    {
        public bool IsSessionAlive()
        {
            var value = HttpContext.Session.GetString("UserSession");
            if (value == null)
            {
                return false;
            }
            else 
                return true;
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            
            if(IsSessionAlive()== false) 
            {
                filterContext.Result = RedirectToAction("Index", "User");
                return;
            }
        }
        public IActionResult Logout()
        {
            
             HttpContext.Session.Clear();

            return RedirectToAction("Index", "Home");
        }

    }
}
