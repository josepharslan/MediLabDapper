using MediLabDapper.Repositories.AboutRepositories;
using Microsoft.AspNetCore.Mvc;

namespace MediLabDapper.ViewComponents
{
    public class _HomeAbout(IAboutRepository _aboutRepository) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = await _aboutRepository.GetResultAboutWithItemsAsync();
            return View(value);
        }
    }
}
