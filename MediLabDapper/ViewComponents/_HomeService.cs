using MediLabDapper.Repositories.ServiceRepositories;
using Microsoft.AspNetCore.Mvc;

namespace MediLabDapper.ViewComponents
{
    public class _HomeService(IServiceRepository _repository) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = await _repository.GetAllServiceAsync();
            return View(value);
        }
    }
}
