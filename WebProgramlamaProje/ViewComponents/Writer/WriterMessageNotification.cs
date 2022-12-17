using Microsoft.AspNetCore.Mvc;

namespace WebProgramlamaProje.ViewComponents.Writer
{
    public class WriterMessageNotification : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
