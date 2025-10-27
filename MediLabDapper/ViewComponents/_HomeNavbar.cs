using MediLabDapper.Repositories.ContactRepositories;
using Microsoft.AspNetCore.Mvc;

namespace MediLabDapper.ViewComponents
{
    public class _HomeNavbar(IContactRepository _repository) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = await _repository.GetAllContactAsync();
            return View(value);
        }
    }
}
