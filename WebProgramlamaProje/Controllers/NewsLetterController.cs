using BussinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebProgramlamaProje.Controllers
{
	public class NewsLetterController : Controller
	{
		NewsLetterManager nm = new NewsLetterManager(new EfNewsLetterRepository());
		[HttpGet]
		public PartialViewResult SubScribeMail()
		{
			return PartialView();
		}


        [HttpPost]
        public PartialViewResult SubScribeMail(NewsLetter p )
        {
			p.MailStatus = true;
			nm.AddNewsLetter(p);
            return PartialView();
        }
    }
}
