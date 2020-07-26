using DependencyInjectionExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjectionExample.Abstractions
{
    public interface IUserRepository
    {
        User GetUser(int id);
        User GetUser(string name);
        User GetLastUser();
        List<User> GetAllUsers();
    }
}
