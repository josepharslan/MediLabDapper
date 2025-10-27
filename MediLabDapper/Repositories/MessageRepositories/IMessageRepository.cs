using MediLabDapper.Dtos.MessageDtos;

namespace MediLabDapper.Repositories.MessageRepositories
{
    public interface IMessageRepository
    {
        Task<IEnumerable<ResultMessageDto>> GetAllMessagesAsync();
        Task CreateMessageAsync(CreateMessageDto message);
        Task DeleteMessageAsync(int id);
    }
}
