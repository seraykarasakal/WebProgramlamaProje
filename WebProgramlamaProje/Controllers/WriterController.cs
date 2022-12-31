using BussinessLayer.Concrete;
using BussinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WebProgramlamaProje.Models;

namespace WebProgramlamaProje.Controllers
{

    public class WriterController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterRepository());

        [Authorize]
        public IActionResult Index()
        {
            var usermail = User.Identity.Name;
            ViewBag.v = usermail;
            Context c = new Context();
            var writerName = c.Writers.Where(x => x.WriterMail ==
            usermail).Select(y => y.WriterName).FirstOrDefault();
            ViewBag.v2 = writerName;

            return View();
        }
        public IActionResult WriterProfile()
        {
            return View();
        }
        public IActionResult WriterMail()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Test()
        {
            return View();
        }

        [AllowAnonymous]
        public PartialViewResult WriterNavbarPartial()
        {
            return PartialView();
        }

        [AllowAnonymous]
        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();
        }
        [HttpGet]
        public IActionResult WriterEditProfile()
        {
            Context c = new Context();
            var usermail = User.Identity.Name;
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            var writervalues = wm.TGetById(writerID);
            return View(writervalues);
        }

        [HttpPost]
        public IActionResult WriterEditProfile(Writer p)
        { 

            wm.TUpdate(p);
            return RedirectToAction("Index", "Dashboard");
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult WriteAdd()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult WriteAdd(AddProfileImage p)
        {
            Writer w =new Writer();
            if(p.WriterImage != null)
            {
                var extension=Path.GetExtension(p.WriterImage.FileName);
                var newimagename=Guid.NewGuid() +extension;
                var location=Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/WriterImage/" ,newimagename);
                var stream = new FileStream(location, FileMode.Create);
                p.WriterImage.CopyTo(stream);
                w.WriterImage = newimagename;
            }
            w.WriterMail = p.WriterMail;
            w.WriterName = p.WriterName;
            w.WriterPassword = p.WriterPassword;
            w.WriterStatus = true;
            w.WriterAbout = p.WriterAbout;

            wm.TAdd(w);
            return RedirectToAction("Index", "Dashboard");
        }

    }
}
