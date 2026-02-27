using ProcessHub.Entities;

namespace ProcessHub.Services.Interfaces
{
    public interface IClientService
    {
        Task<Client> CreateAsync(string name, string email, string documentNumber);

        Task UpdateAsync(Guid id, string name, string email);

        Task<Client?> GetByIdAsync(Guid id);

        Task<IEnumerable<Client>> GetAllAsync();

        Task DeactivateAsync(Guid id);
    }
}