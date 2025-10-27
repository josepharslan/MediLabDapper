using MediLabDapper.Dtos.TestimonialDtos;
using MediLabDapper.Repositories.TestimonialRepositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MediLabDapper.Controllers
{
    public class TestimonialController(ITestimonialRepository _repository) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var value = await _repository.GetAllTestimonialsAsync();
            return View(value);
        }
        public IActionResult CreateTestimonial() => View();
        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(CreateTestimonialDto createTestimonialDto, IFormFile? file)
        {
            await _repository.CreateTestimonialAsync(createTestimonialDto, file);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> UpdateTestimonial(int id)
        {
            var value = await _repository.GetTestimonialByIdAsync(id);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto, IFormFile? file)
        {
            await _repository.UpdateTestimonialAsync(updateTestimonialDto, file);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteTestimonial(int id)
        {
            _repository.DeleteTestimonialAsync(id);
            return RedirectToAction("Index");
        }
    }
}
