using Dapper;
using MediLabDapper.Context;
using MediLabDapper.Dtos.DoctorDtos;
using MediLabDapper.Repositories.FileRepositories;
using System.Data;

namespace MediLabDapper.Repositories.DoctorRepositories
{
    public class DoctorRepository(DapperContext _context, IFileStorage _fileStorage) : IDoctorRepository
    {
        private readonly IDbConnection _connection = _context.CreateConnection();
        public async Task CreateDoctorAsync(CreateDoctorDto createDoctorDto, IFormFile? file)
        {
            var id = Guid.NewGuid();
            string? relativePath = null;

            if (file is not null && file.Length > 0)
            {
                relativePath = await _fileStorage.SavePhotoAsync(id, file);
            }

            var query = "Insert Into Doctors(NameSurname,ImageUrl,Description,DepartmentId) Values (@NameSurname, @ImageUrl, @Description, @DepartmentId)";
            var parameters = new DynamicParameters();
            parameters.Add("@NameSurname", createDoctorDto.NameSurname);
            parameters.Add("@ImageUrl", relativePath);
            parameters.Add("@Description", createDoctorDto.Description);
            parameters.Add("@DepartmentId", createDoctorDto.DepartmentId);


            await _connection.ExecuteAsync(query, parameters);
        }

        public async Task DeleteDoctorAsync(int id)
        {
            var query = "Delete from Doctors where DoctorId = @DoctorId";
            var parameter = new DynamicParameters();
            parameter.Add("@DoctorId", id);
            await _connection.ExecuteAsync(query, parameter);
        }

        public async Task<IEnumerable<ResultDoctorDto>> GetAllDoctorsAsync()
        {
            var query = "Select * From Doctors";
            return await _connection.QueryAsync<ResultDoctorDto>(query);
        }

        public Task<IEnumerable<ResultDoctorWithDepartmentDto>> GetAllDoctorsWithDepartmentAsync()
        {
            var query = "select DoctorId,NameSurname,Doctors.Description,ImageUrl,Name From Doctors inner join departments on doctors.DepartmentId =Departments.DepartmentId";
            return _connection.QueryAsync<ResultDoctorWithDepartmentDto>(query);
        }

        public async Task<GetDoctorByIdDto> GetDoctorByIdAsync(int id)
        {
            var query = "Select * from Doctors Where DoctorId = @DoctorId";
            var parameter = new DynamicParameters();
            parameter.Add("@DoctorId", id);
            return await _connection.QueryFirstOrDefaultAsync<GetDoctorByIdDto>(query, parameter);
        }

        public async Task<IEnumerable<ResultDoctorDto>> GetDoctorsByDepartmentAsync(int departmentId)
        {
            var query = "Select * From Doctors Where DepartmentId = @DepartmentId";
            var parameter = new DynamicParameters();
            parameter.Add("@DepartmentId", departmentId);
            return await _connection.QueryAsync<ResultDoctorDto>(query, parameter);
        }

        public async Task UpdateDoctorAsync(UpdateDoctorDto updateDoctorDto, IFormFile? file)
        {
            var id = Guid.NewGuid();
            string? relativePath = null;

            if (file is not null && file.Length > 0)
            {
                relativePath = await _fileStorage.SavePhotoAsync(id, file);
            }
            var query = "Update Doctors Set NameSurname=@NameSurname,ImageUrl =@ImageUrl, Description = @Description, DepartmentId = @DepartmentId Where DoctorId = @DoctorId";
            var parameters = new DynamicParameters();
            parameters.Add("@DoctorId", updateDoctorDto.DoctorId);
            parameters.Add("@NameSurname", updateDoctorDto.NameSurname);
            parameters.Add("@Description", updateDoctorDto.Description);
            parameters.Add("@DepartmentId", updateDoctorDto.DepartmentId);
            parameters.Add("@ImageUrl", relativePath);
            await _connection.ExecuteAsync(query, parameters);
        }
    }
}
