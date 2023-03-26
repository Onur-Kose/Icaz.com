using Icaz.com.Enums;
using Icaz.com.Models;
using Icaz.com.Models.View_Halper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Diagnostics;

namespace Icaz.com.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<Member> _userManager;
        private readonly RoleManager<Rol> _roleManager;
        private readonly SignInManager<Member> _signInManager;

        private readonly ILogger<HomeController> _logger;
        private readonly IcazContext _db;
        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}
        public HomeController(IcazContext db, UserManager<Member> userManager, RoleManager<Rol> roleManager, SignInManager<Member> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _db = db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            
            var makaleler = _db.Makales.OrderBy(x => x.KacOkundu).Take(5);
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

        
        public IActionResult Makaleler2(int id)
        {
            var makaleler = _db.Makales.Where(c => c.KonuId == id).ToList();
            return View(makaleler);
        }
        public IActionResult Makale(int id)
        {
           
            var makale = _db.Makales.Where(x => x.MakaleId == id).FirstOrDefault();
            var User = _db.Members.Where(x => x.Id == makale.MemberId).FirstOrDefault();
            
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
        public IActionResult Yazar(string itemid)
        {
            var yazar = _db.Members.Where(x => x.Id == itemid).FirstOrDefault();
            return View(yazar);
        }
        [HttpGet]
        public IActionResult SingUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SingUp(Member newUser)
        {
            var varMı = await _userManager.FindByEmailAsync(newUser.Email);

            if (varMı == null)
            {
                Member identityUser = new Member();
                identityUser.Email = newUser.Email;
                identityUser.UserName = newUser.UserName;
                IdentityResult result = await _userManager.CreateAsync(identityUser, newUser.PasswordHash);
                if (result.Succeeded)
                {
                    var resultRole = await _userManager.AddToRoleAsync(identityUser, "USER");
                    if (resultRole.Succeeded)
                    {
                        TempData["Message"] = "Kayıt Başarılı";
                        return RedirectToAction("login", "Home");
                    }
                }
                else
                {
                    TempData["Message"] = "Kayıt başarısız";
                    return View();
                }
                
            }

            TempData["Message"] = "Zaten Kayıtlı Kullanıcı ";
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginUser gelenUser)
        {
            
            if (!ModelState.IsValid)
            {
                TempData["Message"] = "Giriş Modeli Doğru değil";
                return View();
            }
            var userVarMi = await _userManager.FindByEmailAsync(gelenUser.Eposta);
            if (userVarMi == null)
            {
                TempData["Message"] = "Kullanıcı bulunamadı";
                return View();
            }
            var kayitliMi = await _signInManager.PasswordSignInAsync(userVarMi, gelenUser.Password,true,true);
            if (kayitliMi.Succeeded)
            {
                return RedirectToAction("Index", "User");
            }
            TempData["Message"] = "Şifre Hatalı !!";



            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}