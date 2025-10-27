using MediLabDapper.Dtos.AppointmentDtos;

namespace MediLabDapper.Repositories.AppointmentRepositories
{
    public interface IAppointmentRepository
    {
        Task<IEnumerable<ResultAppointmentDto>> GetAppointmentsAsync();
        Task CreateAppointmentAsync(CreateAppointmentDto appointment);
        Task<GetAppointmentByIdDto> GetAppointmentByIdAsync(int id);
        Task DeleteAppointmentAsync(int id);
    }
}
