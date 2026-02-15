namespace ProcessHub.Entities
{
    public class Process : BaseEntity
    {
        public string Title { get; private set; }

        public string Description { get; private set; }

        // Status (enum) - Open, PendingDocumentation, InAnalysis, Approved, Rejected, Completed.

        // ClientId

        // Client

        // AssignedUserId

        // AssignedUser

        // ICollection<Document>

        // ICollection<ProcessHistory>

        protected Process() { }

        public Process(string title, string description)
        {
            Title = title;
            Description = description;
        }

        public void Update(string title, string description)
        {
            Title = title;
            Description = description;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}