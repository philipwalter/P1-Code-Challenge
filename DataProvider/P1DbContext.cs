using Microsoft.EntityFrameworkCore;
using DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataProvider
{
    public class P1DbContext : DbContext
    {

        // CONSTRUCTORS
        public P1DbContext(DbContextOptions<P1DbContext> options) : base(options) { }

        public P1DbContext() { }

        // DBSETS
        public DbSet<ToDoItem> ToDoItems { get; set; }

        // HARD-CODED CONNECTION STRING
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=priority1;Trusted_Connection=True;");
        }

    }
}
