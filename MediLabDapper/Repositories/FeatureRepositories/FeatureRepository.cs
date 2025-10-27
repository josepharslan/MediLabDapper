using Dapper;
using MediLabDapper.Context;
using MediLabDapper.Dtos.FeatureDtos;
using System.Data;

namespace MediLabDapper.Repositories.FeatureRepositories
{
    public class FeatureRepository(DapperContext _context) : IFeatureRepository
    {
        private readonly IDbConnection _dbConnection = _context.CreateConnection();
        public async Task CreateFeatureAsync(CreateFeatureDto createFeatureDto)
        {
            var query = "Insert into Features(Title,Description,Icon) Values(@Title,@Description,@Icon)";
            var parameters = new DynamicParameters(createFeatureDto);

            await _dbConnection.ExecuteAsync(query, parameters);
        }

        public async Task DeleteFeatureAsync(int id)
        {
            var query = "Delete From Features Where FeatureId = @FeatureId";
            var parameter = new DynamicParameters();
            parameter.Add("@FeatureId", id);
            await _dbConnection.ExecuteAsync(query, parameter);
        }

        public async Task<IEnumerable<ResultFeatureDto>> GetAllFeaturesAsync()
        {
            var query = "Select * From Features";
            return await _dbConnection.QueryAsync<ResultFeatureDto>(query);
        }

        public async Task<GetFeatureByIdDto> GetFeatureByIdAsync(int id)
        {
            var query = "Select * From Features Where FeatureId = @FeatureId";
            var parameter = new DynamicParameters();
            parameter.Add("@FeatureId", id);

            return await _dbConnection.QueryFirstOrDefaultAsync<GetFeatureByIdDto>(query, parameter);

        }

        public Task UpdateFeatureAsync(UpdateFeatureDto updateFeatureDto)
        {
            var query = "Update Features Set Title = @Title, Description = @Description, Icon = @Icon Where FeatureId = @FeatureId";
            var parameters = new DynamicParameters(updateFeatureDto);
            return _dbConnection.ExecuteAsync(query, parameters);
        }
    }
}
