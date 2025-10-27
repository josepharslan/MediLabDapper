using Dapper;
using MediLabDapper.Context;
using MediLabDapper.Dtos.MessageDtos;
using System.Data;

namespace MediLabDapper.Repositories.MessageRepositories
{
    public class MessageRepository(DapperContext _dapperContext) : IMessageRepository
    {
        private readonly IDbConnection _connection = _dapperContext.CreateConnection();
        public async Task CreateMessageAsync(CreateMessageDto message)
        {
            var query = "Insert into Messages (Name, Subject, MessageContent) Values (@Name, @Subject, @MessageContent)";
            var parameters = new DynamicParameters();
            parameters.Add("@Name", message.Name);
            parameters.Add("@Subject", message.Subject);
            parameters.Add("@MessageContent", message.MessageContent);
            await _connection.ExecuteAsync(query, parameters);
        }

        public async Task DeleteMessageAsync(int id)
        {
            var query = "Delete from Messages Where MessageId = @MessageId";
            var parameters = new DynamicParameters();
            parameters.Add("@MessageId", id);
            await _connection.ExecuteAsync(query, parameters);
        }

        public async Task<IEnumerable<ResultMessageDto>> GetAllMessagesAsync()
        {
            var query = "Select * from Messages";
            return await _connection.QueryAsync<ResultMessageDto>(query);
        }
    }
}
