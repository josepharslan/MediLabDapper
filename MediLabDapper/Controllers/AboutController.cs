using MediLabDapper.Dtos.AboutDtos;
using MediLabDapper.Repositories.AboutItemRepositories;
using MediLabDapper.Repositories.AboutRepositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MediLabDapper.Controllers
{
    public class AboutController(IAboutRepository _aboutRepository) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var value = await _aboutRepository.GetAllAboutAsync();
            return View(value);
        }
        public async Task<IActionResult> UpdateAbout(int id)
        {
            var value = await _aboutRepository.GetAboutByIdAsync(id);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            await _aboutRepository.UpdateAboutAsync(updateAboutDto);
            return RedirectToAction("Index");
        }
    }
}
