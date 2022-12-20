using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Concrete;
using BussinessLayer.Concrete;

namespace WebProgramlamaProje.Controllers
{
    public class DashboardController : Controller
    {
        
        public IActionResult Index()
        {
            Context c = new Context();
            ViewBag.v1 = c.Blogs.Count().ToString();
            ViewBag.v2 = c.Blogs.Where(x => x.WriterID == 1).Count();
            ViewBag.v3 = c.Categories.Count();
            return View();
        }
    }
}
