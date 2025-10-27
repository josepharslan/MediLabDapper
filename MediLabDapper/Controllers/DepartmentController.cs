using MediLabDapper.Dtos.DepartmentDtos;
using MediLabDapper.Repositories.DepartmentRepositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MediLabDapper.Controllers
{
    public class DepartmentController(IDepartmentRepository _departmentRepository) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var values = await _departmentRepository.GetAllDepartmentsAsync();
            return View(values);
        }

        public IActionResult CreateDepartment()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateDepartment(CreateDepartmentDto createDepartmentDto)
        {
            await _departmentRepository.CreateDepartmentAsync(createDepartmentDto);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> UpdateDepartment(int id)
        {
            var department = await _departmentRepository.GetDepartmentByIdAsync(id);
            return View(department);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateDepartment(UpdateDepartmentDto updateDepartmentDto)
        {
            await _departmentRepository.UpdateDepartmentAsync(updateDepartmentDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteDepartment(int id)
        {
            await _departmentRepository.DeleteDepartmentAsync(id);
            return RedirectToAction("Index");
        }
    }
}
