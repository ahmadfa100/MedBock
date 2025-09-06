using Microsoft.AspNetCore.Mvc;

namespace MedBock.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Register()
        {
            // Renders the existing view at Views/Account/Register.cshtml
            return View();
        }

        // GET: /Account/Login 
        public IActionResult Login()
        {
            return View(); 
        }
    }
}
