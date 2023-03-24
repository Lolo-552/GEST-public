using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Web;
using GEST.Areas.Admin.Models;
using GEST.Data;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Net.Mail;
using System.Net;
using SendGrid;
using SendGrid.Helpers.Mail;
using GEST.Areas.Admin.ViewModels;

namespace GEST.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        private readonly GESTContext _context;

        public LoginController(GESTContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Preview", "Home");
            }
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> Login(Models.Admin admin)
        {
            var result = _context.Admin.Where(x => x.Login == admin.Login && x.Password == admin.Password);
            if (result.Count() != 0)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, admin.Login)
                };

                var claimsIdentity = new ClaimsIdentity(claims, "Login");

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                return RedirectToAction("Preview", "Home");
            }
            else
            {
                ViewData["LoginFlag"] = "Błędny login lub hasło";
                return View();

            }
        }
        [HttpPost]
        public async Task<ActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home", new { area = "" });
        }

        public IActionResult ResetPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(string email)
        {
            var admin = _context.Admin.FirstOrDefault(a => a.Email == email);
            if (admin == null)
            {
                ViewBag.ResetFlag = "Błędny adres e-mail";
                return View("ResetPassword");
            }
            else
            {
                var token = Guid.NewGuid().ToString();
                admin.ResetToken = token;
                _context.Update(admin);
                await _context.SaveChangesAsync();

                var resetLink = Url.Action("ResetPasswordConfirm", "Login", new { token }, Request.Scheme);
                var subject = "Resetowanie hasła GEST";
                var body = $"Resetowanie hasła do panelu admina strony GEST<br>Twój login to: {_context.Admin.FirstOrDefault().Login}<br>Aby zresetować hasło, kliknij w poniższy link<br><a href='{resetLink}'>Resetuj hasło</a>";
                await SendEmail(admin.Email, subject, body);

                ViewBag.ResetFlag = "Link do resetowania hasła został wysłany na podany adres e-mail";
                return View("Login");
            }
        }


        [HttpGet]
        public IActionResult ResetPasswordConfirm(string token)
        {
            var admin = _context.Admin.FirstOrDefault(a => a.ResetToken == token);
            if (admin == null)
            {
                ViewBag.ResetFlag = "Nieprawidłowy token resetowania hasła";
                return View("ResetPassword");
            }
            else
            {
                var model = new ResetPasswordViewModel { Token = token };
                return View(model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> ResetPasswordConfirm(ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var admin = _context.Admin.FirstOrDefault(a => a.ResetToken == model.Token);
                if (admin == null)
                {
                    ViewBag.ResetFlag = "Nieprawidłowy token resetowania hasła";
                    return View("ResetPassword");
                }
                else
                {
                    admin.Password = model.Password;
                    admin.ResetToken = null;
                    _context.Update(admin);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Login");
                }
            }
            return View(model);
        }



        public async Task SendEmail(string toEmail, string subject, string body)
        {
            var apiKey = "api key";
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("example47@gmail.com"),
                Subject = subject,
                HtmlContent = body,
                PlainTextContent = body
            };
            msg.AddTo(new EmailAddress(toEmail));
            var response = await client.SendEmailAsync(msg);
            if (response.StatusCode == HttpStatusCode.Accepted || response.StatusCode == HttpStatusCode.OK)
            {
                Console.WriteLine("Email sent successfully.");
            }
            else
            {
                Console.WriteLine($"Error sending email: {response.StatusCode}");
            }
        }



    }
}

