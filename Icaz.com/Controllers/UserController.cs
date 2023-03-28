using Icaz.com.Models;
using Icaz.com.Models.View_Halper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics.Metrics;

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
        public IActionResult MakaleUpdate(Makale updateMakale)
        {
            KonularıListele();
            var bulunanMakale = _db.Makales.Where(x => x.MakaleId == updateMakale.MakaleId).FirstOrDefault();
            bulunanMakale.MakleAdi = updateMakale.MakleAdi;
            bulunanMakale.MakleOzet = updateMakale.MakleOzet;
            bulunanMakale.MakleMetni = updateMakale.MakleMetni;
            _db.Update(bulunanMakale);
            _db.SaveChanges();



            return RedirectToAction("PersonMakale", "User");
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
                TempData["Message1"] = "İşlem Başarılı,\n\r\n Biliyormuydun sildiğin herşeyi gerçekten veri tabanlarımızdan temizliyoruz";
                return RedirectToAction("PersonMakale", "User");
            }
            else
            {
                TempData["Message"] = "Bu işlem için gerekli yetkiye sahip değilsiniz";
                return RedirectToAction("Login", "home");
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
            var identityUser = await _userManager.FindByNameAsync(User.Identity.Name);
            makale.MemberId = identityUser.Id;
            makale.KacOkundu = 0;
            List<Makale> konrtol = _db.Makales.Where(x => x.MakleMetni == makale.MakleMetni).ToList();
            if (konrtol.Count >= 1)
            {
                TempData["Message"] = "Bu makale daha önce yazılmış gibi görünüyor";
                return View();
            }
            else
            {
                TempData["Message1"] = "Yaşasııın... Şimdi maklelerim sayfasına tıklayarak yazdığın tüm makaleleri görebilirsin";
                _db.Add(makale);
                _db.SaveChanges();

                return View();
            }

        }
        [HttpGet]
        public IActionResult MemberUploadP()
        {
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> MemberUploadP(MemberUploadP file)
        {
            var identityUser = await _userManager.FindByNameAsync(User.Identity.Name);

            if (file != null)
            {

                string imageExtension = Path.GetExtension(file.ImgFile.FileName);

                string imageName = Guid.NewGuid() + imageExtension;

                string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/images/{imageName}");

                using var stream = new FileStream(path, FileMode.Create);

                await file.ImgFile.CopyToAsync(stream);

                identityUser.Fotograf = path;
                //IdentityResult result = await _userManager.UpdateAsync(identityUser);
                TempData["Message1"] = "İşlem Başarı ile gerçekleşti";
                return RedirectToAction("MemberUpdate", "User");

            }
            else
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/images/defult.png");

                using var stream = new FileStream(path, FileMode.Create);
                identityUser.Fotograf = path;
                TempData["Message"] = "UPSS! Yükleme işlemini tamamlayamadık";
                //IdentityResult result = await _userManager.UpdateAsync(identityUser);
                return RedirectToAction("MemberUpdate", "User");

            }

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

            if (member.MemberDetail.IsNullOrEmpty())
            {
                member.MemberDetail = "Anlatmaya Gerek Yok Görüyorsunuz";
            }
            


            var email = _db.Members.Where(x => x.Email == member.Email).ToList();
            var user = _db.Members.Where(x => x.UserName == member.UserName).ToList();
            var userURL = _db.Members.Where(x => x.KullaniciURL == member.KullaniciURL).ToList();
            if (email.Count > 1 || user.Count > 1 || userURL.Count > 1)
            {
                TempData["Message1"] = "Kayıt Başarısız: email, kullanıcı adı veya kullanıcı url daha önce alnımış";
                return View();
            }
            else
            {
                identityUser.Email = member.Email;
                identityUser.Ad = member.Ad;
                identityUser.Soyad = member.Soyad;
                identityUser.Cinsiyet = member.Cinsiyet;
                identityUser.BirthDate = member.BirthDate;
                identityUser.Email = member.Email;
                identityUser.KullaniciURL = member.KullaniciURL;
                identityUser.UserName = member.UserName;
                identityUser.PhoneNumber = member.PhoneNumber;
                identityUser.MemberDetail = member.MemberDetail;
                identityUser.Fotograf = member.Fotograf;
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
        }
        [HttpGet]
        public IActionResult PasswordUpdate()
        {


            return View();

        }
        [HttpPost]
        public async Task<IActionResult> PasswordUpdate(PasswordUpdate newPass)
        {
            var identityUser = await _userManager.FindByNameAsync(User.Identity.Name);
            IdentityResult result = await _userManager.ChangePasswordAsync(identityUser, newPass.OldPassword, newPass.NewPassword);
            if (result.Succeeded)
            {
                TempData["Message1"] = "Şifre Başarı İle güncellendi";
                return RedirectToAction("MemberUpdate", "User");
                
            }
            else
            {
                TempData["Message1"] = "UPSS! Birşeyler Yanlış Görünüyor";
                return View();
            }
            

        }
        public IActionResult LogOut()
        {
            _signInManager.SignOutAsync();

            return RedirectToAction("Login", "home");
        }
        public async Task<IActionResult> MemberDelete()
        {

            var identityUser = await _userManager.FindByNameAsync(User.Identity.Name);

            _db.Remove(identityUser);
            _db.SaveChanges();
            _signInManager.SignOutAsync();
            return RedirectToAction("Index", "home");
        }
        [HttpGet]
        public IActionResult KonuCreate()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> KonuCreate(Konu gelenKonu)
        {

            var identityUser = await _userManager.FindByNameAsync(User.Identity.Name);
            gelenKonu.MemberId = identityUser.Id;

            try
            {
                _db.Add(gelenKonu);
                _db.SaveChanges();
                TempData["Message"] = "Başarı ile eklendi";
                return View();
            }
            catch (Exception)
            {
                TempData["Message"] = "UPSS Birşeyelr Yanlış Görünüyor";
                throw;
            }

            
            
            
        }
        public async Task<IActionResult> UserKonu(int id)
        {
            var identityUser = await _userManager.FindByNameAsync(User.Identity.Name);
            KonuUser konuUser = new KonuUser
            {
                KonuId = id,
                MemberId = identityUser.Id
            };
            _db.Add(konuUser);
            _db.SaveChanges();

            return RedirectToAction("Konular", "home");
        }

        private void KonularıListele()
        {
            var konular = _db.Konus.ToList();
            ViewBag.Konular = konular;
        }

    }
}
