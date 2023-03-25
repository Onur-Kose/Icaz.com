using Microsoft.AspNetCore.Mvc;

namespace Icaz.com.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
