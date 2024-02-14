using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CRUD_WebAPI
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
    }
}
