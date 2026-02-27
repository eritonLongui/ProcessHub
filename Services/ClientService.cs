using ProcessHub.Entities;
using ProcessHub.Repositories.Interfaces;
using ProcessHub.Services.Interfaces;
using ProcessHub.Data;

namespace ProcessHub.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly AppDbContext _context;

        public ClientService(
            IClientRepository clientRepository,
            AppDbContext context)
        {
            _clientRepository = clientRepository;
            _context = context;
        }

        public async Task<Client> CreateAsync(string name, string email, string documentNumber)
        {
            if (await _clientRepository.ExistsByDocumentAsync(documentNumber))
                throw new Exception("Client already exists.");

            var client = new Client(name, email, documentNumber);

            await _clientRepository.AddAsync(client);
            await _context.SaveChangesAsync();

            return client;
        }

        public async Task UpdateAsync(Guid id, string name, string email)
        {
            var client = await _clientRepository.GetByIdAsync(id);

            if (client == null)
                throw new Exception("Client not found.");

            client.Update(name, email);

            _clientRepository.Update(client);
            await _context.SaveChangesAsync();
        }

        public async Task<Client?> GetByIdAsync(Guid id)
        {
            return await _clientRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Client>> GetAllAsync()
        {
            return await _clientRepository.GetAllAsync();
        }

        public async Task DeactivateAsync(Guid id)
        {
            var client = await _clientRepository.GetByIdAsync(id);

            if (client == null)
                throw new Exception("Client not found.");

            client.Deactivate();

            _clientRepository.Update(client);
            await _context.SaveChangesAsync();
        }
    }
}