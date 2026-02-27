using ProcessHub.Entities;
using ProcessHub.Enums;

namespace ProcessHub.Services.Interfaces
{
    public interface IProcessService
    {
        Task<Process> CreateAsync(string title, string description, Guid clientId);

        Task UpdateAsync(Guid id, string title, string description);
    
        Task AssignUserAsync(Guid processId, Guid userId);

        Task ChangeStatusAsync(Guid processId, ProcessStatus newStatus, Guid UserId);

        Task<Process?> GetByIdAsync(Guid id);

        Task<IEnumerable<Process>> GetByClientIdAsync(Guid clientId);

        Task DeactivateAsync(Guid id);
    }
}
