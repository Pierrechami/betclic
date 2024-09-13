using Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class UserRepository
    {
        private readonly List<User> _users = new List<User>(); 
        private int _nextId = 1;

        
        public User? GetById(int id)
        {
            return _users.FirstOrDefault(u => u.Id == id);
        }

        
        public IEnumerable<User> GetAll()
        {
            return _users;
        }

        
        public void Add(User user)
        {
               if (_users.Any(u => u.Email == user.Email))
            {
                throw new InvalidOperationException("The email is already used by another user.");
            }

            user.SetId(_nextId++);
            _users.Add(user);
        }

        
        public void Update(User user)
        {
            var existingUser = GetById(user.Id);
            if (existingUser != null)
            {
                existingUser.SetName(user.Name);
                existingUser.SetEmail(user.Email);
            }
        }

    
        public void Delete(int id)
        {
            var user = GetById(id);
            if (user != null)
            {
                _users.Remove(user);
            }
        }
    }
}
