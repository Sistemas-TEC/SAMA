using LayoutTemplateWebApp.Model;
using Microsoft.EntityFrameworkCore;

namespace LayoutTemplateWebApp.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { 
        
        }

        public DbSet<ApplicationRole> ApplicationRoles { get; set; }
        public DbSet<StudentIntegratec> StudentIntegratecs { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<Canton> Cantons { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Liking> Likings { get; set; }
        public DbSet<Mentor> Mentors { get; set; }
        public DbSet<MentorXLiking> MentorXLikings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationRole>().Ignore(ar => ar.Emails);
            modelBuilder.Entity<MentorXLiking>().HasKey(m => new { m.MentorEmail, m.LikingId });
            // ... (otros mapeos)
        }

    }
}
