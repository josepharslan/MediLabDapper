using Dapper;
using MediLabDapper.Context;
using MediLabDapper.Dtos.ServiceDtos;
using System.Data;

namespace MediLabDapper.Repositories.ServiceRepositories
{
    public class ServiceRepository(DapperContext _dapperContext) : IServiceRepository
    {
        private readonly IDbConnection _dbConnection = _dapperContext.CreateConnection();
        public async Task CreateServiceAsync(CreateServiceDto createServiceDto)
        {
            var query = "Insert Into Services(Title,Description,Icon) Values(@Title,@Description,@Icon)";
            var parameters = new DynamicParameters(createServiceDto);
            await _dbConnection.ExecuteAsync(query, parameters);
        }

        public async Task DeleteServiceAsync(int id)
        {
            var query = "Delete From Services Where ServiceId = @ServiceId";
            var parameters = new DynamicParameters();
            parameters.Add("@ServiceId", id);
            await _dbConnection.ExecuteAsync(query, parameters);
        }

        public Task<IEnumerable<ResultServiceDto>> GetAllServiceAsync()
        {
            var query = "Select * From Services";
            return _dbConnection.QueryAsync<ResultServiceDto>(query);
        }

        public async Task<GetServiceByIdDto> GetServiceByIdAsync(int id)
        {
            var query = "Select * From Services Where ServiceId = @ServiceId";
            var parameters = new DynamicParameters();
            parameters.Add("@ServiceId", id);
            return await _dbConnection.QueryFirstOrDefaultAsync<GetServiceByIdDto>(query, parameters);
        }

        public async Task UpdateServiceAsync(UpdateServiceDto updateServiceDto)
        {
            var query = "Update Services Set Title=@Title, Description=@Description, Icon=@Icon Where ServiceId = @ServiceId";
            var parameters = new DynamicParameters(updateServiceDto);
            await _dbConnection.ExecuteAsync(query, parameters);
        }
    }
}
