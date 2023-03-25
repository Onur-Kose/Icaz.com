using Icaz.com.Enums;
using Icaz.com.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Diagnostics;

namespace Icaz.com.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IcazContext _db;
        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}
        public HomeController(IcazContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            
            var makaleler = _db.Makales.OrderBy(x => x.Puan).Take(5);
            return View(makaleler);
        }
        public IActionResult About()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Makaleler()
        {
            var makaleler = _db.Makales.OrderBy(x => x.KacOkundu).ToList();
            return View(makaleler);
        }

        [Route("deneme")]
        public IActionResult Makaleler2(int id)
        {
            var makaleler = _db.Makales.Where(c => c.KonuId == id).ToList();
            return View(makaleler);
        }
        public IActionResult Makale(int id)
        {
           
            var makale = _db.Makales.Where(x => x.MakaleId == id).FirstOrDefault();
            var User = _db.Users.Where(x => x.UserId == makale.UserId).FirstOrDefault();
            
            makale.KacOkundu = makale.KacOkundu + 1;
            _db.SaveChanges();

            ViewBag.User = User.Ad;
            return View(makale);
        }

        public IActionResult Konular()
        {
            var konular = _db.Konus.ToList();
            return View(konular);
        }
        public IActionResult Yazar(int itemid)
        {
            var yazar = _db.Users.Where(x=>x.UserId == itemid).FirstOrDefault();
            return View(yazar);
        }
        [HttpGet]
        public IActionResult SingUp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SingUp(User newUser)
        {
            var deneme = _db.Users.Select(x => x).ToList();
            foreach (var item in deneme)
            {
                if (item.EmailAdresi == newUser.EmailAdresi || item.Kullaniciadi == newUser.Kullaniciadi)
                {
                    return Ok("Birşeyler Ters Gitti");
                }
                          
            }
            _db.Add(newUser);
            _db.SaveChanges();
            return RedirectToAction("login", "Home");

        }
        [HttpGet]
        public IActionResult Login()
        {

            return View();
        }
        //[HttpPost]
        //public IActionResult Login(User gelenUser)
        //{
        //    var users = _db.Users.ToList();
        //    foreach (var item in users)
        //    {

        //    }
        //    return View();
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}