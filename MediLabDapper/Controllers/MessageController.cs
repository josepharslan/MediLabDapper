using Humanizer;
using MediLabDapper.Dtos.MessageDtos;
using MediLabDapper.Models;
using MediLabDapper.Repositories.ContactRepositories;
using MediLabDapper.Repositories.MessageRepositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MediLabDapper.Controllers
{
    public class MessageController(IMessageRepository _messageRepository, IContactRepository _contactRepository) : Controller
    {
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> SendMessage(CreateMessageDto createMessageDto)
        {
            if (!ModelState.IsValid)
            {
                var contact = await _contactRepository.GetAllContactAsync();
                var vm = new ContactPageVm { Contact = contact.FirstOrDefault(), Form = createMessageDto };
                return View("~/Views/Contact/Contact.cshtml", vm);
            }

            await _messageRepository.CreateMessageAsync(createMessageDto); // Message tablosuna ekle
            TempData["Success"] = "Mesajınız alınmıştır. Teşekkür ederiz.";
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> Index()
        {
            var messages = await _messageRepository.GetAllMessagesAsync();
            return View(messages);
        }
        public async Task<IActionResult> DeleteMessage(int id)
        {
            await _messageRepository.DeleteMessageAsync(id);
            return RedirectToAction("Index");
        }
    }
}
