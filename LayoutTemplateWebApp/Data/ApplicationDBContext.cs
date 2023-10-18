using LayoutTemplateWebApp.Model;
using Microsoft.EntityFrameworkCore;

namespace LayoutTemplateWebApp.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) 
        {
        
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<ApplicationRole> Roles { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<UserAPIModel> UserAPIModels { get; set; }
    }
}
