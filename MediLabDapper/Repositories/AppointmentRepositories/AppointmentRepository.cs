using Dapper;
using MediLabDapper.Context;
using MediLabDapper.Dtos.AppointmentDtos;
using System.Data;

namespace MediLabDapper.Repositories.AppointmentRepositories
{
    public class AppointmentRepository(DapperContext _context) : IAppointmentRepository
    {
        private readonly IDbConnection _connection = _context.CreateConnection();
        public async Task CreateAppointmentAsync(CreateAppointmentDto appointment)
        {
            var query = "Insert into Appointments (Name, Email, PhoneNumber, Date, DepartmentId, DoctorId, Message) Values(@Name, @Email, @PhoneNumber, @Date, @DepartmentId, @DoctorId, @Message)";
            var parameters = new DynamicParameters(appointment);
            await _connection.ExecuteAsync(query, parameters);
        }

        public async Task DeleteAppointmentAsync(int id)
        {
            var query = "Delete From Appointments Where AppointmentId=@AppointmentId";
            var parameters = new DynamicParameters();
            parameters.Add("@AppointmentId", id);
            await _connection.ExecuteAsync(query, parameters);
        }

        public async Task<GetAppointmentByIdDto> GetAppointmentByIdAsync(int id)
        {
            var query = "Select * from Appointments where AppointmentId=@AppointmentId";
            var parameters = new DynamicParameters();
            parameters.Add("@AppointmentId", id);
            return await _connection.QueryFirstOrDefaultAsync<GetAppointmentByIdDto>(query, parameters);
        }

        public async Task<IEnumerable<ResultAppointmentDto>> GetAppointmentsAsync()
        {
            var query = "select A.Name,D.NameSurname,A.PhoneNumber,A.AppointmentId,A.Date From Appointments as A Inner Join Doctors as D on D.DoctorId = A.DoctorId";
            return await _connection.QueryAsync<ResultAppointmentDto>(query);
        }
    }
}
