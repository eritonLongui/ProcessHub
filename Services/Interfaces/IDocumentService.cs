using ProcessHub.Entities;

namespace ProcessHub.Services.Interfaces
{
    public interface IDocumentService
    {
        Task<Document> CreateAsync(string fileName, string filePath, Guid processId);

        Task<Document?> GetByIdAsync(Guid id);

        Task<IEnumerable<Document>> GetByProcessIdAsync(Guid processId);

        Task DeactivateAsync(Guid id);
    }
}