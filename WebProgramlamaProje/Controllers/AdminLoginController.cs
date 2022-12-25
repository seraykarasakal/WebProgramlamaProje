using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebProgramlamaProje.Controllers
{
    public class AdminLoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Index(Admin p)
        {
            Context c = new Context();
            var dataValue = c.Admins.FirstOrDefault(x => x.AdminMail == p.AdminMail && x.AdminPassword == p.AdminPassword);
            if (dataValue != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,p.AdminMail)
                };
                var userIdentitiy = new ClaimsIdentity(claims, "a");
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentitiy);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                return View();
            }
        }
    }
}

