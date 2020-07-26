using DependencyInjectionExample.Abstractions;
using DependencyInjectionExample.Contexts;
using System.Collections.Generic;
using System.Linq;

namespace DependencyInjectionExample.Models
{
    public class UsersRepository : IUserRepository
    {
        UserContext _context;
        public UsersRepository(UserContext context)
        {
            _context = context;   
        }

        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public User GetLastUser()
        {
            return _context.Users.Last();            
        }

        public User GetUser(int id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id);
        }

        public User GetUser(string name)
        {
            return _context.Users.FirstOrDefault(x => x.Name == name);
        }
    }
}
