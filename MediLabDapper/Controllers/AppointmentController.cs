using MediLabDapper.Dtos.AppointmentDtos;
using MediLabDapper.Repositories.AppointmentRepositories;
using MediLabDapper.Repositories.DepartmentRepositories;
using MediLabDapper.Repositories.DoctorRepositories;
using Microsoft.AspNetCore.Mvc;

namespace MediLabDapper.Controllers
{
    public class AppointmentController(IAppointmentRepository _appointmentRepository, IDoctorRepository _doctorRepository, IDepartmentRepository _departmentRepository) : Controller
    {
        [HttpPost]
        public async Task<IActionResult> CreateAppointment(CreateAppointmentDto createAppointmentDto)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.departments = await _departmentRepository.GetAllDepartmentsAsync();
                return Redirect(Url.Action("Index", "Home") + "#appointment");
            }

            await _appointmentRepository.CreateAppointmentAsync(createAppointmentDto);
            TempData["Success"] = "Randevunuz oluşturuldu.";
            return Redirect(Url.Action("Index", "Home") + "#appointment");
        }
        [HttpGet]
        public async Task<IActionResult> Doctors(int departmentId)
        {
            var list = await _doctorRepository.GetDoctorsByDepartmentAsync(departmentId);
            return Json(list.Select(d => new { id = d.DoctorId, name = d.NameSurname }));

        }
        public async Task<IActionResult> Index()
        {
            var appointments =  await _appointmentRepository.GetAppointmentsAsync();
            return View(appointments);
        }
        public async Task<IActionResult> DeleteAppointment(int id)
        {
            await _appointmentRepository.DeleteAppointmentAsync(id);
            return RedirectToAction("Index");
        }
    }
}
