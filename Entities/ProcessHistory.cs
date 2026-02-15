namespace ProcessHub.Entities
{
    public class ProcessHistory : BaseEntity
    {
        public Guid ProcessId { get; private set; }
        public Process Process { get; private set; }

        public string OldStatus { get; private set; }

        public string NewStatus { get; private set; }

        public Guid ChangedByUserId { get; private set; }
        public User ChangedByUser { get; private set; }
        
        public DateTime ChangedAt { get; private set; }

        protected ProcessHistory() { }

        public ProcessHistory(string oldStatus, string newStatus)
        {
            OldStatus = oldStatus;
            NewStatus = newStatus;
        }

        public void Update(string oldStatus, string newStatus)
        {
            OldStatus = oldStatus;
            NewStatus = newStatus;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}