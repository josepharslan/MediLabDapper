using Dapper;
using MediLabDapper.Context;
using MediLabDapper.Dtos.GalleryDtos;
using MediLabDapper.Repositories.FileRepositories;
using System.Data;

namespace MediLabDapper.Repositories.GalleryRepositories
{
    public class GalleryRepository(DapperContext _context, IFileStorage _fileStorage) : IGalleryRepository
    {
        private readonly IDbConnection _connection = _context.CreateConnection();
        public async Task CreateGalleryAsync(CreateGalleryDto createGalleryDto, IFormFile? file)
        {
            var id = Guid.NewGuid();
            string? relativePath = null;

            if (file is not null && file.Length > 0)
            {
                relativePath = await _fileStorage.SavePhotoAsync(id, file);
            }
            var query = "Insert into Galleries(GalleryImageUrl) values (@GalleryImageUrl)";
            var parameters = new DynamicParameters();
            parameters.Add("@GalleryImageUrl", relativePath);

            await _connection.ExecuteAsync(query, parameters);
        }

        public async Task DeleteGalleryAsync(int id)
        {
            var query = "Delete From Galleries where GalleryId=@GalleryId";
            var parameters = new DynamicParameters();
            parameters.Add("@GalleryId", id);
            await _connection.ExecuteAsync(query, parameters);
        }

        public async Task<IEnumerable<ResultGalleryDto>> GetAllGalleryAsync()
        {
            var query = "Select * from galleries";
            return await _connection.QueryAsync<ResultGalleryDto>(query);
        }
    }
}
