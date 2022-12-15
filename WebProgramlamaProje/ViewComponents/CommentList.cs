using Microsoft.AspNetCore.Mvc;
using WebProgramlamaProje.Models;

namespace WebProgramlamaProje.ViewComponents
{
    public class CommentList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var commentvalues = new List<UserComment>
            {
                new UserComment
                {
                    Id = 1,
                    Username ="Seray"
                },
                new UserComment
                {
                    Id = 2,
                    Username ="Ebrar"
                },
                new UserComment
                {
                    Id = 3,
                    Username ="irem"
                },

            };
            return View(commentvalues);
        }
    }
}
