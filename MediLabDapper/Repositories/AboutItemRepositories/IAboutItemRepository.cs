using MediLabDapper.Dtos.AboutDtos;
using MediLabDapper.Dtos.AboutItemDtos;

namespace MediLabDapper.Repositories.AboutItemRepositories
{
    public interface IAboutItemRepository
    {
        Task<IEnumerable<GetAboutItemByIdDto>> GetAllAboutItemByIdAsync(int id);
        Task CreateAboutItemAsync(CreateAboutItemDto createAboutItemDto);
        Task UpdateAboutItemAsync(UpdateAboutItemDto updateAboutItemDto);
        Task DeleteAboutItemAsync(int id);
        Task<GetAboutItemByIdDto> GetAboutItemByIdAsync(int id);
    }
}
