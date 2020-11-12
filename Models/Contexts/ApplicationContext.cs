using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiProj.Models
{
    public class ApplicationContext : IdentityDbContext
    {

        public ApplicationContext(DbContextOptions options) : base(options)
        {

        }


        public DbSet<Customer> Customers { get; set; }

    }
}
