using DemoProjectUsingEF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoProjectUsingEF.LocalDatabase
{
    public partial class LocalDbContext : DbContext
    { 

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb; Database=TestDb; Trusted_Connection=True");
        }


    }
}
