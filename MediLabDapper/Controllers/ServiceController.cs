using MediLabDapper.Dtos.ServiceDtos;
using MediLabDapper.Repositories.ServiceRepositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MediLabDapper.Controllers
{
    public class ServiceController(IServiceRepository _serviceRepository) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var value = await _serviceRepository.GetAllServiceAsync();
            return View(value);
        }

        public IActionResult CreateService() => View();
        [HttpPost]
        public async Task<IActionResult> CreateService(CreateServiceDto createServiceDto)
        {
            await _serviceRepository.CreateServiceAsync(createServiceDto);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> UpdateService(int id)
        {
            var value = await _serviceRepository.GetServiceByIdAsync(id);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateService(UpdateServiceDto updateServiceDto)
        {
            await _serviceRepository.UpdateServiceAsync(updateServiceDto);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteService(int id)
        {
            _serviceRepository.DeleteServiceAsync(id);
            return RedirectToAction("Index");
        }
    }
}
