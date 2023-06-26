using Microsoft.EntityFrameworkCore;
using MyWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApp.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
        public DbSet<Employee> Employee { get; set; }

        public DbSet<Customer> Customer { get; set; }


    }

}
