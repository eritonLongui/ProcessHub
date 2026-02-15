namespace ProcessHub.Entities
{
    public class ProcessHistory : BaseEntity
    {
        public string OldStatus { get; private set; }

        public string NewStatus { get; private set; }

        // ChangedByUserId

        // ChangedByUser

        // ChangedAt

        // ProcessId

        // Process

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