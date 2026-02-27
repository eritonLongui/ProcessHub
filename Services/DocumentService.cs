using ProcessHub.Entities;
using ProcessHub.Repositories.Interfaces;
using ProcessHub.Services.Interfaces;
using ProcessHub.Data;

namespace ProcessHub.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly IRepository<Document> _documentRepository;
        private readonly IProcessRepository _processRepository;
        private readonly AppDbContext _context;

        public DocumentService(
            IRepository<Document> documentRepository,
            IProcessRepository processRepository,
            AppDbContext context)
        {
            _documentRepository = documentRepository;
            _processRepository = processRepository;
            _context = context;
        }

        public async Task<Document> CreateAsync(string fileName, string filePath, Guid processId)
        {
            var process = await _processRepository.GetByIdAsync(processId);

            if (process == null)
                throw new Exception("Process not found.");

            var document = new Document(fileName, filePath, processId);

            await _documentRepository.AddAsync(document);
            await _context.SaveChangesAsync();

            return document;
        }

        public async Task<Document?> GetByIdAsync(Guid id)
        {
            return await _documentRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Document>> GetByProcessIdAsync(Guid processId)
        {
            return await _documentRepository.FindAsync(d => d.ProcessId == processId);
        }

        public async Task DeactivateAsync(Guid id)
        {
            var document = await _documentRepository.GetByIdAsync(id);

            if (document == null)
                throw new Exception("Document not found.");

            document.Deactivate();

            _documentRepository.Update(document);
            await _context.SaveChangesAsync();
        }
    }
}