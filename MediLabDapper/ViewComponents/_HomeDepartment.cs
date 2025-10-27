using MediLabDapper.Repositories.DepartmentRepositories;
using Microsoft.AspNetCore.Mvc;

namespace MediLabDapper.ViewComponents
{
    public class _HomeDepartment(IDepartmentRepository _repository) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = await _repository.GetAllDepartmentsAsync();
            return View(value);
        }
    }
}
