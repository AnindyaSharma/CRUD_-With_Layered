using CRUD__With_Layered.Model.EntityModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD__With_Layered.Database.Database
{
    public class CRUDWithLayeredDbContext:DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            string connectionString = "Server= ANINDYASHARMA01; Database=CRUDWithLayeredDb; Integrated Security=true";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
