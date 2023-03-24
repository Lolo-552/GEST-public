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
    public class NewsController : Controller
    {
        private readonly GESTContext _context;

        public NewsController(GESTContext context)
        {
            _context = context;
        }

        // GET: News
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

            var news = _context.News.OrderByDescending(n => n.DatePublished)
                                    .ToList(); // pobranie danych

            // obliczenie liczby stron
            var pageCount = (int)Math.Ceiling(news.Count() / (double)pageSize);

            // ograniczenie wartości parametru page
            if (page < 1) page = 1;
            if (page > pageCount) page = pageCount;

            // pobranie elementów dla danej strony
            var items = news.Skip((page - 1) * pageSize).Take(pageSize);

            // przekazanie danych do widoku
            ViewBag.PageCount = pageCount;
            ViewBag.PageNumber = page;

            var model = new HomePageModel
            {
                Pages = _context.Pages.OrderByDescending(n => n.DateAdded).ToList(),
                News = items,
                HomePage = _context.HomePage.FirstOrDefault(h => h.Language == lang)
            };
            return View(model);
        }


        // GET: News/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            // domyślny język to polski
            string lang = "pl";
            // sprawdzenie, czy ciasteczko z językiem istnieje
            if (Request.Cookies["lang"] != null)
            {
                lang = Request.Cookies["lang"];
            }
            ViewBag.Lang = lang;

            if (id == null || _context.News == null)
            {
                return NotFound();
            }

            var news = await _context.News.Include(x => x.Photos).Include(y => y.Files).FirstOrDefaultAsync(m => m.Id == id);
            if (news == null)
            {
                return NotFound();
            }

            var model = new HomePageModel
            {
                Pages = _context.Pages.OrderByDescending(n => n.DateAdded).ToList(),
                One_news = news,
                HomePage = _context.HomePage.FirstOrDefault(h => h.Language == lang)
            };

            return View(model);
        }

    }
}

