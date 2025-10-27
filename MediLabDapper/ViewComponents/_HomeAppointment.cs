using MediLabDapper.Repositories.DepartmentRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MediLabDapper.ViewComponents
{
    public class _HomeAppointment(IDepartmentRepository _departmentRepository) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = await _departmentRepository.GetAllDepartmentsAsync();
            ViewBag.departments = (from x in value
                                   select new SelectListItem
                                   {
                                       Text = x.Name,
                                       Value = x.DepartmentId.ToString()
                                   }).ToList();
            return View();
        }
    }
}
