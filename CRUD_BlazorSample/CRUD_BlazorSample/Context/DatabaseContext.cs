using CRUD_BlazorSample.Model;
using Microsoft.EntityFrameworkCore;

namespace CRUD_BlazorSample.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
    }
}
