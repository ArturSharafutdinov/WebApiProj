﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiProj.Models
{
    public class BooksContext : DbContext
    {
        public DbSet<Book> Books { get; set; }


       public BooksContext(DbContextOptions<BooksContext> options) : base(options)
        {

        }

    }
}
