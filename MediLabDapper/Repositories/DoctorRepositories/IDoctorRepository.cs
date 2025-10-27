using MediLabDapper.Dtos.DoctorDtos;

namespace MediLabDapper.Repositories.DoctorRepositories
{
    public interface IDoctorRepository
    {
        Task<IEnumerable<ResultDoctorDto>> GetAllDoctorsAsync();
        Task<IEnumerable<ResultDoctorDto>> GetDoctorsByDepartmentAsync(int departmentId);
        Task<IEnumerable<ResultDoctorWithDepartmentDto>> GetAllDoctorsWithDepartmentAsync();
        Task<GetDoctorByIdDto> GetDoctorByIdAsync(int id);
        Task CreateDoctorAsync(CreateDoctorDto createDoctorDto, IFormFile? file);
        Task UpdateDoctorAsync(UpdateDoctorDto updateDoctorDto, IFormFile? file);
        Task DeleteDoctorAsync(int id);

    }
}
