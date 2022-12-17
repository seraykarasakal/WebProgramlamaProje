using Microsoft.AspNetCore.Mvc;

namespace WebProgramlamaProje.ViewComponents.Writer
{
    public class WriterNotification : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
