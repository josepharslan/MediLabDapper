using MediLabDapper.Repositories.AppointmentRepositories;
using MediLabDapper.Repositories.DepartmentRepositories;
using MediLabDapper.Repositories.DoctorRepositories;
using MediLabDapper.Repositories.MessageRepositories;
using Microsoft.AspNetCore.Mvc;

namespace MediLabDapper.ViewComponents
{
    public class _HomeStats(IDoctorRepository _doctorRepository, IDepartmentRepository _departmentRepository, IAppointmentRepository _appointmentRepository, IMessageRepository _messageRepository) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var doctorCount = await _doctorRepository.GetAllDoctorsAsync();
            var departmentCount = await _departmentRepository.GetAllDepartmentsAsync();
            var appointmentCount = await _appointmentRepository.GetAppointmentsAsync();
            var messageCount = await _messageRepository.GetAllMessagesAsync();
            ViewBag.DoctorCount = doctorCount.Count();
            ViewBag.DepartmentCount = departmentCount.Count();
            ViewBag.AppointmentCount = appointmentCount.Count();
            ViewBag.MessageCount = messageCount.Count();
            return View();
        }
    }
}
