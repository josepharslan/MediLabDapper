using Dapper;
using MediLabDapper.Context;
using MediLabDapper.Dtos.TestimonialDtos;
using MediLabDapper.Repositories.FileRepositories;
using System.Data;

namespace MediLabDapper.Repositories.TestimonialRepositories
{
    public class TestimonialRepository(DapperContext _dapperContext, IFileStorage _fileStorage) : ITestimonialRepository
    {
        private readonly IDbConnection _dbConnection = _dapperContext.CreateConnection();

        public async Task CreateTestimonialAsync(CreateTestimonialDto createTestimonialDto, IFormFile? file)
        {
            var id = Guid.NewGuid();
            string? relativePath = null;

            if (file is not null && file.Length > 0)
            {
                relativePath = await _fileStorage.SavePhotoAsync(id, file);
            }

            var query = "Insert Into Testimonials(NameSurname,Title,Comment,ImageUrl,RatingStar) Values(@NameSurname,@Title,@Comment,@ImageUrl,@RatingStar)";
            var parameters = new DynamicParameters();
            parameters.Add("@NameSurname", createTestimonialDto.NameSurname);
            parameters.Add("@Title", createTestimonialDto.Title);
            parameters.Add("@Comment", createTestimonialDto.Comment);
            parameters.Add("@ImageUrl", relativePath);
            parameters.Add("@RatingStar", createTestimonialDto.RatingStar);
            await _dbConnection.ExecuteAsync(query, parameters);
        }

        public async Task DeleteTestimonialAsync(int id)
        {
            var query = "Delete From Testimonials Where TestimonialId = @TestimonialId";
            var parameters = new DynamicParameters();
            parameters.Add("@TestimonialId", id);
            await _dbConnection.ExecuteAsync(query, parameters);
        }

        public async Task<IEnumerable<ResultTestimonialDto>> GetAllTestimonialsAsync()
        {
            var query = "Select * From Testimonials";
            return await _dbConnection.QueryAsync<ResultTestimonialDto>(query);
        }

        public async Task<GetTestimonialByIdDto> GetTestimonialByIdAsync(int id)
        {
            var query = "Select * From Testimonials Where TestimonialId = @TestimonialId";
            var parameters = new DynamicParameters();
            parameters.Add("@TestimonialId", id);
            return await _dbConnection.QueryFirstOrDefaultAsync<GetTestimonialByIdDto>(query, parameters);
        }

        public async Task UpdateTestimonialAsync(UpdateTestimonialDto updateTestimonialDto, IFormFile file)
        {
            var id = Guid.NewGuid();
            string? relativePath = null;
            if (file is not null && file.Length > 0)
            {
                relativePath = await _fileStorage.SavePhotoAsync(id, file);
                updateTestimonialDto.ImageUrl = relativePath;
            }
            var query = "Update Testimonials Set NameSurname = @NameSurname, Title = @Title, Comment = @Comment, ImageUrl = @ImageUrl, RatingStar = @RatingStar Where TestimonialId = @TestimonialId";
            var parameters = new DynamicParameters();
            parameters.Add("@TestimonialId", updateTestimonialDto.TestimonialId);
            parameters.Add("@NameSurname", updateTestimonialDto.NameSurname);
            parameters.Add("@Title", updateTestimonialDto.Title);
            parameters.Add("@Comment", updateTestimonialDto.Comment);
            parameters.Add("@ImageUrl", relativePath);
            parameters.Add("@RatingStar", updateTestimonialDto.RatingStar);
            await _dbConnection.ExecuteAsync(query, parameters);
        }
    }
}
