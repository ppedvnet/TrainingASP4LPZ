using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EFCodeFirstDemo.Models
{
    public class EfContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Department> Departments { get; set; }

        public EfContext() : base("HelloEfCodeFirstDemo")
        {
        }

        // Fluent API
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .Property(x => x.Occupation)
                .HasColumnName("Job")
                .HasMaxLength(27)
                .IsOptional();

            base.OnModelCreating(modelBuilder);
        }

    }
}