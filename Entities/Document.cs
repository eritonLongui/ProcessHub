namespace ProcessHub.Entities
{
    public class Document : BaseEntity
    {
        public string FileName { get; private set; }

        public string FilePath { get; private set; }

        // ProcessId

        // Process

        protected Document() { }

        public Document(string fileName, string filePath)
        {
            FileName = fileName;
            FilePath = filePath;

        }

        public void Update(string fileName, string filePath)
        {
            FileName = fileName;
            FilePath = filePath;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}