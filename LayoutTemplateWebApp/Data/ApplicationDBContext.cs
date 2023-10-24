using LayoutTemplateWebApp.Model;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace LayoutTemplateWebApp.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) 
        {
        
        }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<ApplicationRole> Roles { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<UserAPIModel> UserAPIModels { get; set; }
        public virtual DbSet<AdminIntegratec> AdminIntegratec { get; set; }
        public virtual DbSet<Campus> Campus { get; set; }
        public virtual DbSet<Canton> Canton { get; set; }
        public virtual DbSet<Degree> Degree { get; set; }
        public virtual DbSet<District> District { get; set; }
        public virtual DbSet<Godchild> Godchild { get; set; }
        public virtual DbSet<Liking> Liking { get; set; }
        public virtual DbSet<Mentor> Mentor { get; set; }
        public virtual DbSet<Organization> Organization { get; set; }
        public virtual DbSet<OrganizationType> OrganizationType { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<PersonXApplicationRole> PersonXApplicationRole { get; set; }
        public virtual DbSet<Province> Province { get; set; }
        public virtual DbSet<School> School { get; set; }
        public virtual DbSet<StudentIntegratec> StudentIntegratec { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdminIntegratec>(entity =>
            {
                entity.HasKey(e => e.email)
                    .HasName("PK__AdminInt__AB6E61655F497497");

                entity.Property(e => e.email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.emailNavigation)
                    .WithOne(p => p.AdminIntegratec)
                    .HasForeignKey<AdminIntegratec>(d => d.email)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AdminInte__email__5629CD9C");
            });
            modelBuilder.Entity<Campus>(entity =>
            {
                entity.Property(e => e.campusName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
                
            });

            modelBuilder.Entity<Canton>(entity =>
            {
                entity.Property(e => e.cantonName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.province)
                    .WithMany(p => p.Canton)
                    .HasForeignKey(d => d.provinceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Canton__province__5AEE82B9");
            });

            modelBuilder.Entity<Degree>(entity =>
            {
                entity.Property(e => e.degreeName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.campus)
                    .WithMany(p => p.Degree)
                    .HasForeignKey(d => d.campusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Degree__campusId__3B75D760");
            });

            modelBuilder.Entity<District>(entity =>
            {
                entity.Property(e => e.districtName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.canton)
                    .WithMany(p => p.District)
                    .HasForeignKey(d => d.cantonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__District__canton__5DCAEF64");
            });

            modelBuilder.Entity<Godchild>(entity =>
            {
                entity.HasKey(e => e.email)
                    .HasName("PK__Godchild__AB6E6165E0BEC7A1");

                entity.Property(e => e.email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.consideration)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.emailNavigation)
                    .WithOne(p => p.Godchild)
                    .HasForeignKey<Godchild>(d => d.email)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Godchild__email__693CA210");

                entity.HasMany(d => d.liking)
                    .WithMany(p => p.email)
                    .UsingEntity<Dictionary<string, object>>(
                        "GodchildXLiking",
                        l => l.HasOne<Liking>().WithMany().HasForeignKey("likingId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__GodchildX__likin__72C60C4A"),
                        r => r.HasOne<Godchild>().WithMany().HasForeignKey("email").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__GodchildX__email__71D1E811"),
                        j =>
                        {
                            j.HasKey("email", "likingId").HasName("PK__Godchild__4F160F07DE7521EC");

                            j.ToTable("GodchildXLiking");

                            j.IndexerProperty<string>("email").HasMaxLength(255).IsUnicode(false);
                        });
            });

            modelBuilder.Entity<Liking>(entity =>
            {
                entity.Property(e => e.likingName)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Mentor>(entity =>
            {
                entity.HasKey(e => e.email)
                    .HasName("PK__Mentor__AB6E61650E292766");

                entity.Property(e => e.email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.emailNavigation)
                    .WithOne(p => p.Mentor)
                    .HasForeignKey<Mentor>(d => d.email)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Mentor__email__66603565");

                entity.HasMany(d => d.liking)
                    .WithMany(p => p.mentorEmail)
                    .UsingEntity<Dictionary<string, object>>(
                        "MentorXLiking",
                        l => l.HasOne<Liking>().WithMany().HasForeignKey("likingId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__MentorXLi__likin__6EF57B66"),
                        r => r.HasOne<Mentor>().WithMany().HasForeignKey("mentorEmail").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__MentorXLi__mento__6E01572D"),
                        j =>
                        {
                            j.HasKey("mentorEmail", "likingId").HasName("PK__MentorXL__2C803933E31FBF12");

                            j.ToTable("MentorXLiking");

                            j.IndexerProperty<string>("mentorEmail").HasMaxLength(255).IsUnicode(false);
                        });
            });

            modelBuilder.Entity<Organization>(entity =>
            {
                entity.HasKey(e => e.email)
                    .HasName("PK__Organiza__AB6E61655D92D59D");

                entity.Property(e => e.email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.organizationName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.organizationPassword)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.degree)
                    .WithMany(p => p.Organization)
                    .HasForeignKey(d => d.degreeId)
                    .HasConstraintName("FK__Organizat__degre__4BAC3F29");

                entity.HasOne(d => d.type)
                    .WithMany(p => p.Organization)
                    .HasForeignKey(d => d.typeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Organizat__typeI__4CA06362");
            });

            modelBuilder.Entity<OrganizationType>(entity =>
            {
                entity.Property(e => e.typeName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasKey(e => e.email)
                    .HasName("PK__Person__AB6E6165AA50D485");

                entity.Property(e => e.email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.firstLastName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.personName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.personPassword)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.secondLastName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PersonXApplicationRole>(entity =>
            {
                entity.HasKey(e => new { e.email, e.applicationRoleId })
                    .HasName("PK__PersonXA__1ADDA527E8690D65");

                entity.Property(e => e.email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.emailNavigation)
                    .WithMany(p => p.PersonXApplicationRole)
                    .HasForeignKey(d => d.email)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PersonXAp__email__52593CB8");
            });

            modelBuilder.Entity<Province>(entity =>
            {
                entity.Property(e => e.provinceName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<School>(entity =>
            {
                entity.Property(e => e.schoolName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.campus)
                    .WithMany(p => p.School)
                    .HasForeignKey(d => d.campusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__School__campusId__3E52440B");
            });

            modelBuilder.Entity<StudentIntegratec>(entity =>
            {
                entity.HasKey(e => e.email)
                    .HasName("PK__StudentI__AB6E6165EC26026C");

                entity.Property(e => e.email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.numContact)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.canton)
                    .WithMany(p => p.StudentIntegratec)
                    .HasForeignKey(d => d.cantonId)
                    .HasConstraintName("FK__StudentIn__canto__628FA481");

                entity.HasOne(d => d.district)
                    .WithMany(p => p.StudentIntegratec)
                    .HasForeignKey(d => d.districtId)
                    .HasConstraintName("FK__StudentIn__distr__6383C8BA");

                entity.HasOne(d => d.emailNavigation)
                    .WithOne(p => p.StudentIntegratec)
                    .HasForeignKey<StudentIntegratec>(d => d.email)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__StudentIn__email__60A75C0F");

                entity.HasOne(d => d.province)
                    .WithMany(p => p.StudentIntegratec)
                    .HasForeignKey(d => d.provinceId)
                    .HasConstraintName("FK__StudentIn__provi__619B8048");
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
