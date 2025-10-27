namespace MediLabDapper.Dtos.MessageDtos
{
    public class UpdateMessageDto
    {
        public int MessageId { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
        public string MessageContent { get; set; }
    }
}
