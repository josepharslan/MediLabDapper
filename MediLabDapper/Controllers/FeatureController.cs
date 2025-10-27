using MediLabDapper.Dtos.FeatureDtos;
using MediLabDapper.Repositories.FeatureRepositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MediLabDapper.Controllers
{
    public class FeatureController(IFeatureRepository _featureRepository) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var value = await _featureRepository.GetAllFeaturesAsync();
            return View(value);
        }
        public IActionResult CreateFeature()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateFeature(CreateFeatureDto createFeatureDto)
        {
            await _featureRepository.CreateFeatureAsync(createFeatureDto);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> UpdateFeature(int id)
        {
            var value = await _featureRepository.GetFeatureByIdAsync(id);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            await _featureRepository.UpdateFeatureAsync(updateFeatureDto);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteFeature(int id)
        {
            await _featureRepository.DeleteFeatureAsync(id);
            return RedirectToAction("Index");
        }
    }
}
