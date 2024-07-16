using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer;

namespace ProjectMvvmByErm.Model.Data
{
    public class ApplicationContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Department> Departments { get; set; }

        public ApplicationContext() 
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ProjectMvvmDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
