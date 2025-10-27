using Microsoft.AspNetCore.Mvc;

namespace MediLabDapper.ViewComponents
{
    public class _HomeScript : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
