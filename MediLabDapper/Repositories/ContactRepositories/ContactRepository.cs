using Dapper;
using MediLabDapper.Context;
using MediLabDapper.Dtos.ContactDtos;
using System.Data;

namespace MediLabDapper.Repositories.ContactRepositories
{
    public class ContactRepository(DapperContext _context) : IContactRepository
    {
        private readonly IDbConnection _dbconnection = _context.CreateConnection();

        public async Task<IEnumerable<ResultContactDto>> GetAllContactAsync()
        {
            var query = "Select * from Contacts";
            return await _dbconnection.QueryAsync<ResultContactDto>(query);
        }

        public async Task<GetContactByIdDto> GetContactByIdAsync(int id)
        {
            var query = "Select * from Contacts Where ContactId = @ContactId";
            var parameters = new DynamicParameters();
            parameters.Add("ContactId", id);
            return await _dbconnection.QueryFirstOrDefaultAsync<GetContactByIdDto>(query, parameters);
        }

        public async Task UpdateContactAsync(UpdateContactDto contact)
        {
            var query = "Update Contacts Set Location=@Location, PhoneNumber = @PhoneNumber,Email = @Email Where ContactId = @ContactId";
            var parameters = new DynamicParameters();
            parameters.Add("ContactId", contact.ContactId);
            parameters.Add("Location", contact.Location);
            parameters.Add("PhoneNumber", contact.PhoneNumber);
            parameters.Add("Email", contact.Email);
            await _dbconnection.ExecuteAsync(query, parameters);
        }
    }
}
