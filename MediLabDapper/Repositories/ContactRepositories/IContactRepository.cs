using MediLabDapper.Dtos.ContactDtos;

namespace MediLabDapper.Repositories.ContactRepositories
{
    public interface IContactRepository
    {
        Task<IEnumerable<ResultContactDto>> GetAllContactAsync();
        Task<GetContactByIdDto> GetContactByIdAsync(int id);
        Task UpdateContactAsync(UpdateContactDto contact);
    }
}
