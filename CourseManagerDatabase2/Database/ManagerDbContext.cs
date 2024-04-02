using CourseManagerDatabase.Entitys;
using CourseManagerDatabase.Entitys.Configurations;
using CourseManagerDatabase.Tools;
using Microsoft.EntityFrameworkCore;

namespace CourseManagerDatabase.Database
{
    public class ManagerDbContext : DbContext
    {
        public DbSet<CourseRecord> Courses { get; set; }
        public DbSet<GroupRecord> Groups { get; set; }
        public DbSet<StudentRecord> Students { get; set; }
        public DbSet<TeacherRecord> Teachers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CourseConfiguration());
            modelBuilder.ApplyConfiguration(new GroupConfiguration());
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new TeacherConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        readonly string path = FileHelper.GetDbPath();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite($"Data Source={path + "CourseManager.db"}");
    }
}
