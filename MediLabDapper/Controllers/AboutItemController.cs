using MediLabDapper.Dtos.AboutItemDtos;
using MediLabDapper.Repositories.AboutItemRepositories;
using MediLabDapper.Repositories.AboutRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace MediLabDapper.Controllers
{
    public class AboutItemController(IAboutItemRepository _aboutItemRepository) : Controller
    {
        public async Task<IActionResult> Details(int id)
        {
            var value = await _aboutItemRepository.GetAllAboutItemByIdAsync(id);
            return View(value);
        }
        public async Task<IActionResult> UpdateAboutItem(int id)
        {
            var aboutItem = await _aboutItemRepository.GetAboutItemByIdAsync(id);
            return View(aboutItem);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateAboutItem(UpdateAboutItemDto updateAboutItemDto)
        {
            await _aboutItemRepository.UpdateAboutItemAsync(updateAboutItemDto);
            return RedirectToAction("Index", "About");
        }
        public IActionResult CreateAboutItem(int id)
        {
            return View(new CreateAboutItemDto { AboutId = id });
        }
        [HttpPost]
        public async Task<IActionResult> CreateAboutItem(CreateAboutItemDto createAboutItemDto)
        {
            await _aboutItemRepository.CreateAboutItemAsync(createAboutItemDto);
            return RedirectToAction("Details", "AboutItem", new { id = createAboutItemDto.AboutId });
        }
        public async Task<IActionResult> DeleteAboutItem(int id)
        {
            await _aboutItemRepository.DeleteAboutItemAsync(id);
            return RedirectToAction("Index", "About");
        }
    }
}
