using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiProj.Models
{
    public class CommentsContext : DbContext
    {

        public CommentsContext(DbContextOptions<CommentsContext> options) : base(options)
        {
        }

        public DbSet<Comment> Comments { get; set; }

    }
}
