using MediLabDapper.Dtos.AboutDtos;

namespace MediLabDapper.Repositories.AboutRepositories
{
    public interface IAboutRepository
    {
        Task<IEnumerable<ResultAboutDto>> GetAllAboutAsync();
        Task<IEnumerable<ResultAboutWithItemDto>> GetResultAboutWithItemsAsync();
        Task<GetAboutByIdDto> GetAboutByIdAsync(int id);
        Task UpdateAboutAsync(UpdateAboutDto updateAboutDto);

    }
}
