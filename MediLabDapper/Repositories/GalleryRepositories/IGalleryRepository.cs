using MediLabDapper.Dtos.GalleryDtos;

namespace MediLabDapper.Repositories.GalleryRepositories
{
    public interface IGalleryRepository
    {
        Task<IEnumerable<ResultGalleryDto>> GetAllGalleryAsync();
        Task CreateGalleryAsync(CreateGalleryDto createGalleryDto, IFormFile? file);
        Task DeleteGalleryAsync(int id);
    }
}
