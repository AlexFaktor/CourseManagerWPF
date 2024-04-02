using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseManagerDatabase.Entitys.Configurations
{
    public class CourseConfiguration : IEntityTypeConfiguration<CourseRecord>
    {
        public void Configure(EntityTypeBuilder<CourseRecord> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(32);

            builder.HasMany(c => c.Groups)
                .WithOne(g => g.Course)
                .HasForeignKey(g => g.CourseId);
        }
    }
}
