using MediLabDapper.Dtos.FeatureDtos;

namespace MediLabDapper.Repositories.FeatureRepositories
{
    public interface IFeatureRepository
    {
        public Task<IEnumerable<ResultFeatureDto>> GetAllFeaturesAsync();
        public Task CreateFeatureAsync(CreateFeatureDto createFeatureDto);
        public Task DeleteFeatureAsync(int id);
        public Task UpdateFeatureAsync(UpdateFeatureDto updateFeatureDto);
        public Task<GetFeatureByIdDto> GetFeatureByIdAsync(int id);
    }
}
