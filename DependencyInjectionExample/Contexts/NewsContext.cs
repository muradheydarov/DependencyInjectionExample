using DependencyInjectionExample.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjectionExample.Contexts
{
    public class NewsContext : DbContext
    {
        public NewsContext(DbContextOptions<NewsContext> options) :
            base(options)
        {
        }

        public DbSet<News> News { get; set; }

        public DbSet<DependencyInjectionExample.Models.User> User { get; set; }
    }
}
