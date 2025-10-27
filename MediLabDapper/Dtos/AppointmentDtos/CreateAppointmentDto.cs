namespace MediLabDapper.Dtos.AppointmentDtos
{
    public class CreateAppointmentDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Date { get; set; }
        public int DepartmentId { get; set; }
        public int DoctorId { get; set; }
        public string Message { get; set; }
    }
}
