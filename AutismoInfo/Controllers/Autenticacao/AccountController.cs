using Microsoft.AspNetCore.Mvc;

namespace AutismoInfo.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }
    }
}
