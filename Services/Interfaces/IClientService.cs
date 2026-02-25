using ProcessHub.Entities;

namespace ProcessHub.Services.Interfaces
{
    public interface IClientService
    {
        Task<Client> CreateAsync(string name, string documentNumber);

        Task UpdateAsync(Guid id, string name, string documentNumber);

        Task<Client?> GetByIdAsync(Guid id);

        Task<IEnumerable<Client>> GetAllAsync();

        Task DeleteAsync(Guid id);
    }
}