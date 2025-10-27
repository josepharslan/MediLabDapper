using MediLabDapper.Repositories.GalleryRepositories;
using Microsoft.AspNetCore.Mvc;

namespace MediLabDapper.ViewComponents
{
    public class _HomeGallery(IGalleryRepository _repository) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = await _repository.GetAllGalleryAsync();
            return View(value);
        }
    }
}
