using Dapper;
using MediLabDapper.Context;
using MediLabDapper.Dtos.AboutDtos;
using System.Data;

namespace MediLabDapper.Repositories.AboutRepositories
{
    public class AboutRepository(DapperContext _dapperContext) : IAboutRepository
    {
        private readonly IDbConnection _connection = _dapperContext.CreateConnection();

        public async Task<GetAboutByIdDto> GetAboutByIdAsync(int id)
        {
            var query = "Select * From Abouts where AboutId=@AboutId";
            var parameters = new DynamicParameters();
            parameters.Add("@AboutId", id);
            return await _connection.QueryFirstOrDefaultAsync<GetAboutByIdDto>(query, parameters);

        }

        public async Task<IEnumerable<ResultAboutDto>> GetAllAboutAsync()
        {
            var query = "Select * From Abouts";
            return await _connection.QueryAsync<ResultAboutDto>(query);
        }

        public async Task<IEnumerable<ResultAboutWithItemDto>> GetResultAboutWithItemsAsync()
        {
            var query = "select Abouts.AboutId,AboutDescription,Title,AboutItems.Description,AboutItems.Icon From Abouts Inner Join AboutItems on Abouts.AboutId = AboutItems.AboutId";
            return await _connection.QueryAsync<ResultAboutWithItemDto>(query);
        }

        public async Task UpdateAboutAsync(UpdateAboutDto updateAboutDto)
        {
            var query = "Update Abouts Set AboutDescription = @AboutDescription where AboutId=@AboutId";
            var parameters = new DynamicParameters();
            parameters.Add("@AboutId", updateAboutDto.AboutId);
            parameters.Add("@AboutDescription", updateAboutDto.AboutDescription);
            await _connection.ExecuteAsync(query, parameters);
        }
    }
}
