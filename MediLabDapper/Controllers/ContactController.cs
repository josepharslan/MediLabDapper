using MediLabDapper.Dtos.ContactDtos;
using MediLabDapper.Repositories.ContactRepositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MediLabDapper.Controllers
{
    public class ContactController(IContactRepository _repository) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var value = await _repository.GetAllContactAsync();
            return View(value);
        }
        public async Task<IActionResult> UpdateContact(int id)
        {
            var value = await _repository.GetContactByIdAsync(id);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateContact(UpdateContactDto updateContactDto)
        {
            await _repository.UpdateContactAsync(updateContactDto);
            return RedirectToAction("Index");
        }
    }
}
