namespace MediLabDapper.Dtos.ContactDtos
{
    public class GetContactByIdDto
    {
        public int ContactId { get; set; }
        public string Location { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
