using Icaz.com.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Icaz.com.Controllers
{

    [Authorize]
    public class UserController : Controller
    {
        private readonly UserManager<Member> _userManager;
        private readonly RoleManager<Rol> _roleManager;
        private readonly SignInManager<Member> _signInManager;
        private readonly IcazContext _db;

        public UserController(IcazContext db, UserManager<Member> userManager, RoleManager<Rol> roleManager, SignInManager<Member> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _db = db;
        }
        public IActionResult Index()
        {
            var makaleler = _db.Makales.OrderBy(x => x.KacOkundu).Take(5);
            return RedirectToAction("Index", "Home");
        }
        public IActionResult About()
        {
            
            return RedirectToAction("About", "Home");
        }

        public async Task<IActionResult> PersonMakale()
        {
            var identityUser = await _userManager.FindByNameAsync(User.Identity.Name);
            var personMakales = _db.Makales.Where(x => x.MemberId == identityUser.Id).ToList();

            return View(personMakales);
        }
        [HttpGet]
        public async Task<IActionResult> MakaleUpdate(int id)
        {
            KonularıListele();
            var identityUser = await _userManager.FindByNameAsync(User.Identity.Name);
            var updateMakale = _db.Makales.Where(x => x.MakaleId == id).Where(x => x.MemberId == identityUser.Id).FirstOrDefault();

            return View(updateMakale);
        }
        [HttpPost]
        public async Task<IActionResult> MakaleUpdate(Makale updateMakale)
        {
            KonularıListele();
            var bulunanMakale = _db.Makales.Where(x => x.MakaleId == updateMakale.MakaleId).FirstOrDefault();
            bulunanMakale.MakleAdi = updateMakale.MakleAdi;
            bulunanMakale.MakleOzet = updateMakale.MakleOzet;
            bulunanMakale.MakleMetni = updateMakale.MakleMetni;
            _db.Update(bulunanMakale);
            _db.SaveChanges();


            
            return RedirectToAction("PersonMakale" ,"User");
        }
        [HttpGet]
        public async Task<IActionResult> MakaleDelete(int id)
        {
            var identityUser = await _userManager.FindByNameAsync(User.Identity.Name);
            var deleteMakale = _db.Makales.Where(x => x.MakaleId == id).Where(x => x.MemberId == identityUser.Id).FirstOrDefault();

            return View(deleteMakale);
            
        }
        [HttpPost]
        public async Task<IActionResult> MakaleDelete(Makale deleteMakale)
        {
            var identityUser = await _userManager.FindByNameAsync(User.Identity.Name);
            var bulunanMakale = _db.Makales.Where(x => x.MakaleId == deleteMakale.MakaleId).Where(x => x.MemberId == identityUser.Id).FirstOrDefault();
            if (bulunanMakale != null)
            {
                _db.Remove(bulunanMakale);
                _db.SaveChanges();
                TempData["Message1"] = "İşlem Başarılı";
                return RedirectToAction("PersonMakale", "User");
            }
            else
            {
                TempData["Message"] = "Bu işlem için gerekli yetkiye sahip değilsiniz";
                return RedirectToAction("Login","home");
            }
            
        }
        [HttpGet]
        public IActionResult MakaleCreate()
        {
            KonularıListele();

            return View();
        }



        [HttpPost]
        public async Task<IActionResult> MakaleCreate(Makale makale)
        {
            KonularıListele();
            //makale.KonuId = ViewBag.KonuId;
            var identityUser = await _userManager.FindByNameAsync(User.Identity.Name);
            makale.MemberId = identityUser.Id;
            makale.KacOkundu = 0;
            _db.Add(makale);
            _db.SaveChanges();

            return View();
        }
        [HttpGet]
        public async Task<IActionResult> MemberUpdate()
        {
            var identityUser = await _userManager.FindByNameAsync(User.Identity.Name);

            return View(identityUser);
        }
        [HttpPost]
        public async Task<IActionResult> MemberUpdate(Member member)
        {
            
            var identityUser = await _userManager.FindByNameAsync(User.Identity.Name);
            identityUser.Ad = member.Ad;
            identityUser.Soyad = member.Soyad;
            identityUser.Cinsiyet = member.Cinsiyet;
            identityUser.BirthDate = member.BirthDate;
            identityUser.UserName = member.UserName;
            identityUser.Email = member.Email;
            identityUser.KullaniciURL = member.KullaniciURL;
            identityUser.PhoneNumber = member.PhoneNumber;
            IdentityResult result = await _userManager.UpdateAsync(identityUser);
            if (result.Succeeded)
            {
                TempData["Message"] = "Kayıt Başarılı";
                return View();
            }
            else
            {
                TempData["Message1"] = "Kayıt Başarısız";
                return View();
            }
                
        }
        public async Task<IActionResult> LogOut()
        {
            _signInManager.SignOutAsync();

            return RedirectToAction("Login" , "home");
        }

        private void KonularıListele()
        {
            var konular = _db.Konus.ToList();
            ViewBag.Konular = konular;
        }

    }
}
