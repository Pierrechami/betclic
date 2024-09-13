namespace Domain.Entities {
   public class User
    {
        public int Id { get; private set; } 
        public string Name { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;

        public User(string name, string email)
        {
            SetName(name);
            SetEmail(email);
        }

        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("You must enter a valid name.");
            Name = name;
        }

        public void SetEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
                throw new ArgumentException("You have not entered a valid email address");
            Email = email;
        }

        // This method is used because we're using an in-memory repository
        // where IDs need to be manually assigned. In a real database, this
        // would not be necessary, as the ID would be auto-generated.
        public void SetId(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID must be a positive integer.");
            Id = id;
        }
    }
}