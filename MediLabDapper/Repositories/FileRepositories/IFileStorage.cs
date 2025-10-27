namespace MediLabDapper.Repositories.FileRepositories
{
    public interface IFileStorage
    {
        Task<string> SavePhotoAsync(Guid doctorId, IFormFile file);
        Task DeleteAsync(string path);
    }
}
