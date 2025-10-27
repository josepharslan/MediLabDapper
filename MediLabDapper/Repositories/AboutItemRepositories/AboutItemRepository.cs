using Dapper;
using MediLabDapper.Context;
using MediLabDapper.Dtos.AboutDtos;
using MediLabDapper.Dtos.AboutItemDtos;
using System.Data;

namespace MediLabDapper.Repositories.AboutItemRepositories
{
    public class AboutItemRepository(DapperContext _dapperContext) : IAboutItemRepository
    {
        private readonly IDbConnection _connection = _dapperContext.CreateConnection();
        public async Task CreateAboutItemAsync(CreateAboutItemDto createAboutItemDto)
        {
            var query = "Insert into AboutItems(Title,AboutId,Description,Icon) Values(@Title,@AboutId,@Description,@Icon)";
            var parameters = new DynamicParameters(createAboutItemDto);
            await _connection.ExecuteAsync(query, parameters);
        }

        public async Task DeleteAboutItemAsync(int id)
        {
            var query = "Delete From AboutItems Where AboutItemId = @AboutItemId";
            var parameter = new DynamicParameters();
            parameter.Add("@AboutItemId", id);
            await _connection.ExecuteAsync(query, parameter);
        }

        public async Task<GetAboutItemByIdDto> GetAboutItemByIdAsync(int id)
        {
            var query = "Select * From AboutItems Where AboutItemId = @AboutItemId";
            var parameter = new DynamicParameters();
            parameter.Add("@AboutItemId", id);
            return await _connection.QueryFirstOrDefaultAsync<GetAboutItemByIdDto>(query, parameter);
        }

        public async Task<IEnumerable<GetAboutItemByIdDto>> GetAllAboutItemByIdAsync(int id)
        {
            var query = "Select * From AboutItems where AboutId = @AboutId";
            var parameters = new DynamicParameters();
            parameters.Add("@AboutId", id);
            return await _connection.QueryAsync<GetAboutItemByIdDto>(query, parameters);
        }

        public async Task UpdateAboutItemAsync(UpdateAboutItemDto updateAboutItemDto)
        {
            var query = "Update AboutItems Set Title = @Title, Description = @Description, Icon = @Icon,AboutId=@AboutId Where AboutItemId = @AboutItemId";
            var parameters = new DynamicParameters(updateAboutItemDto);
            await _connection.ExecuteAsync(query, parameters);
        }
    }
}
