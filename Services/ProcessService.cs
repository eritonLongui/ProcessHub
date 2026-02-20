using ProcessHub.Entities;
using ProcessHub.Repositories.Interfaces;
using ProcessHub.Services.Interfaces;
using ProcessHub.Enums;
using ProcessHub.Data;

namespace ProcessHub.Services
{
    public class ProcessService : IProcessService
    {
        private readonly IProcessRepository _processRepository;
        private readonly IRepository<Client> _clientRepository;
        private readonly AppDbContext _context;

        public ProcessService(
            IProcessRepository processRepository,
            IRepository<Client> clientRepository,
            AppDbContext context)
        {
            _processRepository = processRepository;
            _clientRepository = clientRepository;
            _context = context;
        }

        public async Task<Process> CreateAsync(string title, string description, ProcessStatus status, Guid clientId)
        {
            var client = await _clientRepository.GetByIdAsync(clientId);

            if (client == null)
                throw new Exception("Client not found.");

            var process = new Process(title, description, clientId);

            await _processRepository.AddAsync(process);

            await _context.SaveChangesAsync();

            return process;
        }

        public async Task UpdateAsync(Guid id, string title, string description, ProcessStatus status)
        {
            var process = await _processRepository.GetByIdAsync(id);

            if (process == null)
                throw new Exception("Process not found.");

            process.Update(title, description);

            _processRepository.Update(process);

            await _context.SaveChangesAsync();
        }

        public async Task AssignUserAsync(Guid processId, Guid userId)
        {
            var process = await _processRepository.GetByIdAsync(processId);

            if (process == null)
                throw new Exception("Process not found.");

            process.AssignUser(userId);

            _processRepository.Update(process);

            await _context.SaveChangesAsync();
        }

        public async Task ChangeStatusAsync(Guid processId, ProcessStatus newStatus)
        {
            var process = await _processRepository.GetByIdAsync(processId);

            if (process == null)
                throw new Exception("Process not found.");

            process.ChangeStatus(newStatus);

            _processRepository.Update(process);

            await _context.SaveChangesAsync();
        }

        public async Task<Process?> GetByIdAsync(Guid id)
        {
            return await _processRepository.GetWithDetailsAsync(id);
        }

        public async Task<IEnumerable<Process>> GetByClientIdAsync(Guid clientId)
        {
            return await _processRepository.GetByClientIdAsync(clientId);
        }
    }
}
