using MediLabDapper.Dtos.DoctorDtos;
using MediLabDapper.Repositories.DepartmentRepositories;
using MediLabDapper.Repositories.DoctorRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace MediLabDapper.Controllers
{
    public class DoctorController(IDoctorRepository _doctorRepository, IDepartmentRepository _departmentRepository) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var values = await _doctorRepository.GetAllDoctorsWithDepartmentAsync();
            return View(values);
        }
        public async Task<IActionResult> DeleteDoctor(int id)
        {
            await _doctorRepository.DeleteDoctorAsync(id);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> CreateDoctor()
        {
            var departments = await _departmentRepository.GetAllDepartmentsAsync();

            ViewBag.departments = (from x in departments
                                   select new SelectListItem
                                   {
                                       Text = x.Name,
                                       Value = x.DepartmentId.ToString()
                                   }).ToList();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateDoctor(CreateDoctorDto createDoctorDto, IFormFile? file)
        {
            await _doctorRepository.CreateDoctorAsync(createDoctorDto, file);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateDoctor(int id)
        {
            var departments = await _departmentRepository.GetAllDepartmentsAsync();
            ViewBag.departments = (from x in departments
                                   select new SelectListItem
                                   {
                                       Text = x.Name,
                                       Value = x.DepartmentId.ToString()
                                   }).ToList();

            var doctor = await _doctorRepository.GetDoctorByIdAsync(id);
            return View(doctor);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateDoctor(UpdateDoctorDto updateDoctorDto, IFormFile? file)
        {
            await _doctorRepository.UpdateDoctorAsync(updateDoctorDto, file);
            return RedirectToAction("Index");
        }
    }
}
