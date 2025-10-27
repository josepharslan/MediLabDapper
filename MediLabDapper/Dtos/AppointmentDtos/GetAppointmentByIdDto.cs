namespace MediLabDapper.Dtos.AppointmentDtos
{
    public class GetAppointmentByIdDto
    {
        public int AppointmentId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Date { get; set; }
        public string NameSurname { get; set; }
        public string Message { get; set; }
    }
}
