using MediLabDapper.Dtos.ContactDtos;
using MediLabDapper.Dtos.MessageDtos;

namespace MediLabDapper.Models
{
    public class ContactPageVm
    {
        public ResultContactDto Contact { get; set; } = new();
        public CreateMessageDto Form { get; set; } = new();
    }
}
