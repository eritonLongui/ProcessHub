namespace ProcessHub.Entities
{
    public class Client : BaseEntity
    {
        public string Name { get; private set; }

        public string Email { get; private set; }

        public string Document { get; private set; }

        protected Client() { }

        public Client(string name, string email, string document)
        {
            Name = name;
            Email = email;
            Document = document;
        }

        public void Update(string name, string email)
        {
            Name = name;
            Email = email;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
