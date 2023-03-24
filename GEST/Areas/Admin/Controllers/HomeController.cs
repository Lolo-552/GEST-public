using GEST.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using GEST.Areas.Admin.Models;
namespace GEST.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly GESTContext _context;
        public HomeController(GESTContext context)
        {
            _context = context;
        }

        public IActionResult Preview()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SaveHomePageChanges(string heroHeader, string heroP, string aboutUsHeader, string aboutUsP, string joinUsHeader, string joinUsP, string projectHeader, string newsHeader, string achievementsHeader, string publicationsHeader, string managementHeader, string email)
        {
            _context.HomePage.FirstOrDefault(h => h.Language == "pl").Email = email;
            _context.HomePage.FirstOrDefault(h => h.Language == "en").Email = email;
            // domyślny język to angielski
            string lang = "pl";

            // sprawdzenie, czy ciasteczko z językiem istnieje
            if (Request.Cookies["lang"] != null)
            {
                lang = Request.Cookies["lang"];
            }
            ViewBag.Lang = lang;

            var homePage = _context.HomePage.FirstOrDefault(h => h.Language == lang);
            homePage.HeroHeader = heroHeader;
            homePage.HeroP = heroP;
            homePage.AboutUsHeader = aboutUsHeader;
            homePage.AboutUsP = aboutUsP;
            homePage.JoinUsHeader = joinUsHeader;
            homePage.JoinUsP = joinUsP;
            homePage.ProjectHeader = projectHeader;
            homePage.NewsHeader = newsHeader;
            homePage.AchievementsHeader = achievementsHeader;
            homePage.PublicationsHeader = publicationsHeader;
            homePage.ManagementHeader = managementHeader;

            _context.SaveChanges();
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> UploadImage(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                var fileExtension = Path.GetExtension(file.FileName);
                var fileName = Guid.NewGuid().ToString() + fileExtension;
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot","img","uploads", fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                return Json(new { location = "/../img/uploads/" + fileName });
            }
            return BadRequest();
        }

        public IActionResult Account()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Account(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                ModelState.AddModelError(string.Empty, "Podane hasło jest nieprawidłowe.");
                return NotFound();
            }

            var admin = _context.Admin.FirstOrDefault();
            admin.Password = password;
            _context.Update(admin);
            await _context.SaveChangesAsync();

            return RedirectToAction("Login","Login");

        }



    }

}
