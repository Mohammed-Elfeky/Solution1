using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using models;
namespace d1.Model
{
    public class context: IdentityDbContext
    {
        public context(DbContextOptions options) : base(options){}
        public  DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Product> products { get; set; }


    }
}
