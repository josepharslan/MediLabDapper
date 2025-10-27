using MediLabDapper.Dtos.GalleryDtos;
using MediLabDapper.Repositories.GalleryRepositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MediLabDapper.Controllers
{
    public class GalleryController(IGalleryRepository _repository) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var value = await _repository.GetAllGalleryAsync();
            return View(value);
        }
        public IActionResult CreateGallery()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateGallery(CreateGalleryDto createGalleryDto, IFormFile? file)
        {
            await _repository.CreateGalleryAsync(createGalleryDto, file);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> DeleteGallery(int id)
        {
            await _repository.DeleteGalleryAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
