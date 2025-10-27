using MediLabDapper.Dtos.MessageDtos;
using MediLabDapper.Models;
using MediLabDapper.Repositories.ContactRepositories;
using MediLabDapper.Repositories.MessageRepositories;
using Microsoft.AspNetCore.Mvc;

namespace MediLabDapper.ViewComponents
{
    public class _HomeContact(IContactRepository _repository, IMessageRepository _messageRepository) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = await _repository.GetAllContactAsync();
            var vm = new ContactPageVm
            {
                Contact = value.FirstOrDefault(),
                Form = new CreateMessageDto()
            };
            return View(vm);
        }
    }
}
