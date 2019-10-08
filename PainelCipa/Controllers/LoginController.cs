using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PainelCipa.Models;
using System.Web.Helpers;
using System.Text;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

namespace PainelCipa.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly PainelCipaContext _context;
        public LoginController(PainelCipaContext context)
        {
            _context = context;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(Login login)
        {
            login.Password = System.Web.Helpers.Crypto.Hash(login.Password, "MD5").ToLower();

            if (_context.Login.Where(l => l.Username == login.Username && l.Password == login.Password).FirstOrDefault() != null)
            {
                var claims = new List<Claim>
                {
                    new Claim("user", login.Username)
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    AllowRefresh = true,
                    IsPersistent = true,
                    ExpiresUtc = DateTimeOffset.UtcNow.AddHours(1.0),
                };
                //await HttpContext.SignInAsync(new ClaimsPrincipal(new ClaimsIdentity(claims, "Cookies", "user", "role")));
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

                return Redirect("/Home/");
            }
            else
            {
                ViewBag.LoginError = "Usuário ou senha incorretos.";
                return View("Index");
            }
        }
        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/Login/");
        }
    }
}