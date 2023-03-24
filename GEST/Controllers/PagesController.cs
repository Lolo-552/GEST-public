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
    public class PagesController : Controller
    {
        private readonly GESTContext _context;

        public PagesController(GESTContext context)
        {
            _context = context;
        }
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


            if (id == null || _context.Pages == null)
            {
                return NotFound();
            }

            var page = await _context.Pages.Include(x => x.Photos).Include(y => y.Files).FirstOrDefaultAsync(m => m.Id == id);
            if (page == null)
            {
                return NotFound();
            }

            var model = new HomePageModel
            {
                Pages = _context.Pages.OrderByDescending(n => n.DateAdded).ToList(),
                Page = page,
                HomePage = _context.HomePage.FirstOrDefault(h => h.Language == lang)
            };

            return View(model);
        }

    }
}
