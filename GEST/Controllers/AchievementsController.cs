using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GEST.Data;
using GEST.Models;
using GEST.ViewModels;

namespace GEST.Controllers
{
    public class AchievementsController : Controller
    {
        private readonly GESTContext _context;

        public AchievementsController(GESTContext context)
        {
            _context = context;
        }

        // GET: Achievements
        //pageSize - liczba elementów na jednej stronie
        public IActionResult Index(int page = 1, int pageSize = 6)
        {
            // domyślny język to polski
            string lang = "pl";
            // sprawdzenie, czy ciasteczko z językiem istnieje
            if (Request.Cookies["lang"] != null)
            {
                lang = Request.Cookies["lang"];
            }
            ViewBag.Lang = lang;

            var achievements = _context.Achievements.OrderByDescending(n => n.DatePublished)
                                    .ToList();

            // obliczenie liczby stron
            var pageCount = (int)Math.Ceiling(achievements.Count() / (double)pageSize);

            // ograniczenie wartości parametru page
            if (page < 1) page = 1;
            if (page > pageCount) page = pageCount;

            // pobranie elementów dla danej strony
            var items = achievements.Skip((page - 1) * pageSize).Take(pageSize);

            // przekazanie danych do widoku
            ViewBag.PageCount = pageCount;
            ViewBag.PageNumber = page;

            var model = new HomePageModel
            {
                Pages = _context.Pages.OrderByDescending(n => n.DateAdded).ToList(),
                Achievements = achievements,
                HomePage = _context.HomePage.FirstOrDefault(h => h.Language == lang)
            };

            return View(model);
        }


        // GET: Achievements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            // domyślny język to angielski
            string lang = "pl";

            // sprawdzenie, czy ciasteczko z językiem istnieje
            if (Request.Cookies["lang"] != null)
            {
                lang = Request.Cookies["lang"];
            }
            ViewBag.Lang = lang;

            if (id == null || _context.Achievements == null)
            {
                return NotFound();
            }

            var achievement = await _context.Achievements.Include(x => x.Photos).Include(y => y.Files).FirstOrDefaultAsync(m => m.Id == id);
            if (achievement == null)
            {
                return NotFound();
            }

            var model = new HomePageModel
            {
                Pages = _context.Pages.OrderByDescending(n => n.DateAdded).ToList(),
                Achievement = achievement,
                HomePage = _context.HomePage.FirstOrDefault(h => h.Language == lang)
            };

            return View(model);
        }

    }
}

