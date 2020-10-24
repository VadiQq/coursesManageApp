using Microsoft.EntityFrameworkCore;

namespace CoursesManageApp.Database.Data
{
    public partial class CoursesDatabaseContext : DbContext
    {
        public CoursesDatabaseContext()
        {
            Database.EnsureCreated();
        }

        public CoursesDatabaseContext(DbContextOptions<CoursesDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<CourseTime> CoursesTime { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=coursesdb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("courses");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cost)
                    .HasColumnName("cost")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<CourseTime>(entity =>
            {
                entity.ToTable("courses_time");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CourseId).HasColumnName("course_id");

                entity.Property(e => e.EndTime).HasColumnName("end_time");

                entity.Property(e => e.StartTime).HasColumnName("start_time");

                entity.Property(e => e.CourseDay).HasColumnName("course_day");

                entity.HasOne(d => d.Course)
                    .WithOne(d=>d.CourseTime)
                    .HasConstraintName("FK__courses_t__cours__29572725");
            });
        }
    }
}
