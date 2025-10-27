using MediLabDapper.Repositories.DoctorRepositories;
using Microsoft.AspNetCore.Mvc;

namespace MediLabDapper.ViewComponents
{
    public class _HomeDoctor(IDoctorRepository _repository) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = await _repository.GetAllDoctorsAsync();
            return View(value);
        }
    }
}
