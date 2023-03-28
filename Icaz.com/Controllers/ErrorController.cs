using Microsoft.AspNetCore.Mvc;

namespace Icaz.com.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult PageNotFound(int code)
        {
            return View();
        }
        
    }
}
