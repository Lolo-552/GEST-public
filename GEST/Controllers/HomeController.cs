//using AspNetCore;
using GEST.Data;
using GEST.Models;
using GEST.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;


namespace GEST.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly GESTContext _context;

        public HomeController(ILogger<HomeController> logger, GESTContext context)
        {
            _logger = logger;
            _context = context;
        }
        //GET : Gest
        public ActionResult Index()
        {
            // domyślny język to angielski
            string lang = "pl";

            // sprawdzenie, czy ciasteczko z językiem istnieje
            if (Request.Cookies["lang"] != null)
            {
                lang = Request.Cookies["lang"];
            }
            ViewBag.Lang = lang;

            var model = new HomePageModel
             {
                 Projects = _context.Projects.OrderByDescending(n => n.DateAdded).ToList(),
                 News = _context.News.OrderByDescending(n => n.DatePublished).ToList(),
                 Management = _context.Management.ToList(),
                 Achievements = _context.Achievements.OrderByDescending(n => n.DatePublished).ToList(),
                 Publications = _context.Publications.OrderByDescending(n =>n.DateAdded).ToList(),
                 Pages = _context.Pages.OrderByDescending(n=>n.DateAdded).ToList(),
                 HomePage = _context.HomePage.FirstOrDefault(h => h.Language == lang)
        };
            return View(model);
        }

        public IActionResult SetLanguage(string lang)
        {
            if (lang != null)
            {
                CookieOptions option = new CookieOptions();
                option.Expires = DateTime.Now.AddYears(1);
                Response.Cookies.Append("lang", lang, option);
            }

            // przekierowuje użytkownika na tę samą stronę, na której aktualnie się znajduje
            string returnUrl = Request.Headers["Referer"].ToString();
            return Redirect(returnUrl);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}