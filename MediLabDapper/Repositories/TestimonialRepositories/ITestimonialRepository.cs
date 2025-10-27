using MediLabDapper.Dtos.TestimonialDtos;

namespace MediLabDapper.Repositories.TestimonialRepositories
{
    public interface ITestimonialRepository
    {
        Task<IEnumerable<ResultTestimonialDto>> GetAllTestimonialsAsync();
        Task<GetTestimonialByIdDto> GetTestimonialByIdAsync(int id);
        Task CreateTestimonialAsync(CreateTestimonialDto createTestimonialDto, IFormFile? file);
        Task UpdateTestimonialAsync(UpdateTestimonialDto updateTestimonialDto, IFormFile? file);
        Task DeleteTestimonialAsync(int id);
    }
}
