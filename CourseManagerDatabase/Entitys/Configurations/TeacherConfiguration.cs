using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseManagerDatabase.Entitys.Configurations
{
    public class TeacherConfiguration : IEntityTypeConfiguration<TeacherRecord>
    {
        public void Configure(EntityTypeBuilder<TeacherRecord> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(32);

            builder.Property(p => p.Surname)
                .IsRequired()
                .HasMaxLength(32);

            builder.Property(p => p.Patronymic)
                .IsRequired()
                .HasMaxLength(32);

            builder.Property(p => p.Email)
                .HasMaxLength(255);

            builder.HasMany(s => s.Groups)
                .WithOne(g => g.Teacher)
                .HasForeignKey(g => g.TeacherId);
        }
    }
}
