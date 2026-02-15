namespace ProcessHub.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; private set; }

        public string Email { get; private set; }

        public string PasswordHash { get; private set; }

        // Role (enum) - Admin, User.

        // ICollection<Process> AssignadProcesses { get; private set; }

        // ICollection<ProcessHistory> ChangesMade { get; private set; }

        protected User() { }

        public User(string name, string email, string passwordHash)
        {
            Name = name;
            Email = email;
            PasswordHash = passwordHash;
        }

        public void Update(string name, string email)
        {
            Name = name;
            Email = email;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}