using ProcessHub.Entities;
using ProcessHub.Enums;

namespace ProcessHub.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> CreateAsync(string name, string email, string passwordHash, UserRole role);

        Task UpdateAsync(Guid id, string name, string email);

        Task ChangePasswordAsync(Guid id, string newPasswordHash);
        
        Task<User?> GetByIdAsync(Guid id);

        Task<IEnumerable<User>> GetAllAsync();

        Task DeactivateAsync(Guid id);
    }
}