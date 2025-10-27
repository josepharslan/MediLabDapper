using MediLabDapper.Dtos.ServiceDtos;

namespace MediLabDapper.Repositories.ServiceRepositories
{
    public interface IServiceRepository
    {
        Task<IEnumerable<ResultServiceDto>> GetAllServiceAsync();
        Task<GetServiceByIdDto> GetServiceByIdAsync(int id);
        Task CreateServiceAsync(CreateServiceDto createServiceDto);
        Task UpdateServiceAsync(UpdateServiceDto updateServiceDto);
        Task DeleteServiceAsync(int id);
    }
}
