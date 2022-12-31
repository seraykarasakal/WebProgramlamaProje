using BussinessLayer.Concrete;
using BussinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;
using System.Drawing.Design;

namespace WebProgramlamaProje.Controllers
{
    
    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        Context c = new Context();

        
        public IActionResult Index()
        {
            var values = bm.GetBlogListWithCategory();
            return View(values);
        }
        public IActionResult BlogReadAll(int id)
        {
            ViewBag.i = id;
            var values =bm.GetBlogById(id);
            return View(values);
        }
        public IActionResult BlogListByWriter()
        {
            
            var usermail = User.Identity.Name;
            var writerID = c.Writers.Where(x => x.WriterMail ==
            usermail).Select(y => y.WriterID).FirstOrDefault();
            var values =bm.GetListWithCategoryByWriterBm(writerID);
            return View(values);
        }
        [HttpGet]
        public IActionResult BlogAdd()
        {
                List<SelectListItem> categoryvalues = (from x in cm.GetList()
                                                       select new SelectListItem
                                                       {
                                                           Text = x.CategoryName,
                                                           Value = x.CategoryID.ToString()
                                                       }).ToList();
                ViewBag.cv = categoryvalues;
                return View();
            
        }
        [HttpPost]
        public IActionResult BlogAdd(Blog p)
        {

            
            var usermail = User.Identity.Name;
            var writerID = c.Writers.Where(x => x.WriterMail ==
            usermail).Select(y => y.WriterID).FirstOrDefault();
            BlogValidator bv = new BlogValidator();
            ValidationResult results = bv.Validate(p);
            if (results.IsValid)
            {
                p.BlogStatus = true;
                p.BlogCreateDate = "18.12.2022";
                p.WriterID = writerID;
                bm.TAdd(p);
                return RedirectToAction("BlogListByWriter", "Blog");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        //{
        //    BlogValidator bv = new BlogValidator();
        //    var writerMail = User.Identity.Name;
        //    var writerID = p.Writers.Where(x => x.WriterMail == writerMail).Select(y => y.WriterID).FirstOrDefault();
        //    BlogValidator av = new BlogValidator();
        //    ValidationResult results = bv.Validate(p);
        //    if (results.IsValid)
        //    {
        //        p.BlogStatus = true;
        //        p.BlogID = writerID;
        //        bm.TAdd(p);
        //        return RedirectToAction("BlogListByUser", "Blog");
        //    }
        //    else
        //    {
        //        foreach (var item in results.Errors)
        //        {
        //            ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
        //        }
        //    }
        //    return View();
        //}
        public IActionResult DeleteBlog(int id)
        {
            var blogvalue= bm.TGetById(id); 
            bm.TDelete(blogvalue);
            return RedirectToAction("BlogListByWriter");
        }
        [HttpGet]
        public IActionResult EditBlog(int id)
        {
            var blogvalue = bm.TGetById(id);
            List<SelectListItem> categoryvalues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryvalues;
            return View(blogvalue);
        }

        [HttpPost]
        public IActionResult EditBlog(Blog p)
        {
            var usermail = User.Identity.Name;
            var writerID = c.Writers.Where(x => x.WriterMail ==
            usermail).Select(y => y.WriterID).FirstOrDefault();
            p.WriterID = writerID;
            p.BlogCreateDate = "18.12.2022";
            bm.TUpdate(p);
            return RedirectToAction("BlogListByWriter");
        }
    }
}
