using MediLabDapper.Repositories.AboutRepositories;
using MediLabDapper.Repositories.ContactRepositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MediLabDapper.ViewComponents
{
    public class _HomeFooter(IContactRepository _repository) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = await _repository.GetAllContactAsync();
            return View(value);
        }
    }
}
