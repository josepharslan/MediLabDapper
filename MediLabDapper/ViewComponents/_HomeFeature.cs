using MediLabDapper.Repositories.FeatureRepositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MediLabDapper.ViewComponents
{
    public class _HomeFeature(IFeatureRepository _repository) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = await _repository.GetAllFeaturesAsync();
            return View(value);
        }
    }
}
