using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GEST.Data;
using GEST.Models;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;
using Microsoft.AspNetCore.Hosting;
using System.Net.Http.Headers;
using System.ComponentModel.DataAnnotations;
using static System.Net.Mime.MediaTypeNames;
using NuGet.ProjectModel;
using System.ComponentModel;
using static System.Net.WebRequestMethods;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.IdentityModel.Tokens;

namespace GEST.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class NewsController : Controller
    {
        private readonly GESTContext _context;
        private IWebHostEnvironment _hostingEnv;
        public NewsController(GESTContext context, IWebHostEnvironment hostingEnv)
        {
            _context = context;
            _hostingEnv = hostingEnv;

        }

        // GET: Admin/News
        public async Task<IActionResult> Index()
        {
            return View(await _context.News.ToListAsync());
        }

        // GET: Admin/News/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.News == null)
            {
                return NotFound();
            }

            var news = await _context.News
                .FirstOrDefaultAsync(m => m.Id == id);

            if (news == null)
            {
                return NotFound();
            }

            return View(news);
        }

        // GET: Admin/News/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/News/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Title_en,ShortDescription,ShortDescription_en,DatePublished,Description,Description_en")] News news, List<IFormFile> photos, List<IFormFile> files)
        {

            //sprawdzam czy zdjęcie nie ma złego rozszerzenia
            bool fileValid = ValidateFiles(photos, files, ModelState);
            if (!fileValid) return View(news);

            if (ModelState.IsValid)
            {
                //dodaje projekty do bazy żeby wiedzieć jakie id;
                _context.Add(news);
                await _context.SaveChangesAsync();

                //zdjęcia
                List<Photos> savedPhotos = await SavePhotosAsync(news.Id, photos);

                //pliki
                List<Files> savedFiles = await SaveFilesAsync(news.Id, files);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(news);
            }
        }


        // GET: Admin/News/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.News == null)
            {
                return NotFound();
            }

            var news = await _context.News.FindAsync(id);
            if (news == null)
            {
                return NotFound();
            }
            await _context.Entry(news).Collection(i => i.Photos).LoadAsync();
            await _context.Entry(news).Collection(i => i.Files).LoadAsync();

            return View(news);
        }

        // POST: Admin/News/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Title_en,ShortDescription,ShortDescription_en,DatePublished,Description,Description_en")] News news, List<IFormFile> photos, string? selectedPhotosIds, List<IFormFile> files, string? selectedFilesIds)
        {
            if (id != news.Id)
            {
                return NotFound();
            }

            //sprawdzam czy zdjęcie nie ma złego rozszerzenia
            //sprawdzam czy zdjęcie nie ma złego rozszerzenia
            bool fileValid = ValidateFiles(photos, files, ModelState);
            if (!fileValid) return View(news);

            if (ModelState.IsValid)
            {
                try
                {
                    //zdjęcia
                    List<Photos> savedPhotos = await SavePhotosAsync(news.Id, photos);

                    //pliki
                    List<Files> savedFiles = await SaveFilesAsync(news.Id, files);

                    _context.Update(news);

                    //usuawnie zdjęć
                    if (!string.IsNullOrEmpty(selectedPhotosIds))
                    {
                        var selectedIdArray = selectedPhotosIds.Split(',').Select(x => int.Parse(x)).ToArray(); ;
                        foreach (var item in selectedIdArray)
                        {
                            var projectPhotos = await _context.Photos.Include(p => p.News).FirstOrDefaultAsync(m => m.Id == item);
                            if (projectPhotos != null)
                            {
                                FileInfo file = new FileInfo(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot") + projectPhotos.PhotoPath.Replace("~", ""));
                                if (file.Exists)
                                {
                                    file.Delete();
                                }
                                _context.Photos.Remove(projectPhotos);
                            }
                        }
                    }
                    //usuwanie plików
                    if (!string.IsNullOrEmpty(selectedFilesIds))
                    {
                        var selectedIdArray = selectedFilesIds.Split(',').Select(x => int.Parse(x)).ToArray(); ;
                        foreach (var item in selectedIdArray)
                        {
                            var file = await _context.Files.Include(p => p.News).FirstOrDefaultAsync(m => m.Id == item);
                            if (file != null)
                            {
                                FileInfo fileInfo = new FileInfo(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot") + file.FilePath.Replace("~", ""));
                                if (fileInfo.Exists)
                                {
                                    fileInfo.Delete();
                                }
                                _context.Files.Remove(file);
                            }
                        }
                    }
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NewsExists(news.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            else
            {
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        // tu możesz wyświetlić komunikat o błędzie
                        var errorMessage = error.ErrorMessage;
                        var exception = error.Exception;
                    }
                }
                return View(news);
            }

        }

        // GET: Admin/News/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.News == null)
            {
                return NotFound();
            }

            var news = await _context.News
                .FirstOrDefaultAsync(m => m.Id == id);
            if (news == null)
            {
                return NotFound();
            }

            return View(news);
        }

        // POST: Admin/News/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.News == null)
            {
                return Problem("Entity set 'GestDbContext.News'  is null.");
            }

            var news = _context.News.Include(n => n.Photos)
                                    .Include(n => n.Files)
                                    .FirstOrDefault(n => n.Id == id);

            //usuwanie zdjęć/filmów i projektu

            if (news != null)
            {
                string rootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");

                if (news.Photos != null)
                {
                    _context.Photos.RemoveRange(news.Photos);

                    foreach (var item in _context.Photos.Where(x => x.NewsId == news.Id))
                    {
                        FileInfo file = new FileInfo(rootPath + item.PhotoPath.Replace("~", ""));
                        if (file.Exists)
                        {
                            file.Delete();
                        }
                    }
                }

                if (news.Files != null)
                {
                    _context.Files.RemoveRange(news.Files);

                    foreach (var item in _context.Files.Where(x => x.NewsId == news.Id))
                    {
                        FileInfo file = new FileInfo(rootPath + item.FilePath.Replace("~", ""));
                        if (file.Exists)
                        {
                            file.Delete();
                        }
                    }
                }

                _context.News.Remove(news);
            }


            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NewsExists(int id)
        {
            return _context.News.Any(e => e.Id == id);
        }


        public bool ValidateFiles(List<IFormFile> photos, List<IFormFile> files, ModelStateDictionary modelState)
        {
            //walidacja po stronie serwera, jeśli chcesz dodać wiecej rozszerzenie zmień również liste rozszerzeń w pliku admin-panel.js
            bool filesValid = true;

            foreach (var item in photos)
            {
                if (!new[] { ".jpg", ".jpeg", ".png" }.Contains(Path.GetExtension(item.FileName.ToLower())))
                {
                    modelState.AddModelError("photoExtError", "Akceptowane są tylko pliki .png .jpeg .jpg");
                    filesValid = false;
                }
            }

            foreach (var item in files)
            {
                if (!new[] { ".pdf", ".txt", ".docx" }.Contains(Path.GetExtension(item.FileName.ToLower())))
                {
                    modelState.AddModelError("fileExtError", "Akceptowane są tylko pliki .pdf .txt .docx");
                    filesValid = false;
                }
            }

            return filesValid;
        }
        private async Task<List<Photos>> SavePhotosAsync(int newsId, List<IFormFile> photos)
        {
            List<Photos> savedPhotos = new List<Photos>();
            if (photos != null)
            {
                foreach (var formFile in photos)
                {
                    Photos photo = new Photos();
                    Random random = new Random();
                    string randomString = new string(Enumerable.Range(0, 10).Select(i => (char)('a' + random.Next(26))).ToArray());
                    string formFileName = ContentDispositionHeaderValue.Parse(formFile.ContentDisposition).FileName.Trim('"');
                    string filePath = "news_" + newsId + "_image_" + randomString + Path.GetExtension(formFileName);
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "news", filePath);

                    using (System.IO.Stream stream = new FileStream(path, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                    }

                    photo.PhotoPath = "~/img/news/" + filePath;
                    photo.NewsId = newsId;
                    _context.Photos.Add(photo);
                    await _context.SaveChangesAsync();

                    savedPhotos.Add(photo);
                }
            }
            return savedPhotos;
        }
        private async Task<List<Files>> SaveFilesAsync(int newsId, List<IFormFile> files)
        {
            List<Files> savedFiles = new List<Files>();

            if (files != null)
            {
                foreach (var item in files)
                {
                    Files file = new Files();

                    file.FileName = ContentDispositionHeaderValue.Parse(item.ContentDisposition).FileName.Trim('"');
                    string filePath = "project_" + newsId + "_file_" + file.FileName + "_" + Path.GetExtension(file.FileName);
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "files", "news", filePath);

                    using (System.IO.Stream stream = new FileStream(path, FileMode.Create))
                    {
                        await item.CopyToAsync(stream);
                    }

                    file.FilePath = "~/files/news/" + filePath;
                    file.NewsId = newsId;
                    _context.Files.Add(file);
                    await _context.SaveChangesAsync();

                    savedFiles.Add(file);
                }
            }

            return savedFiles;
        }



    }
}
