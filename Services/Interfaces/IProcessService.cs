using ProcessHub.Entities;
using ProcessHub.Enums;

namespace ProcessHub.Services.Interfaces
{
    public interface IProcessService
    {
        Task<Process> CreateAsync(string title, string description, ProcessStatus status, Guid clientId);

        Task UpdateAsync(Guid id, string title, string description, ProcessStatus status);

        Task<Process?> GetByIdAsync(Guid id);

        Task<IEnumerable<Process>> GetByClientIdAsync(Guid clientId);
    }
}
