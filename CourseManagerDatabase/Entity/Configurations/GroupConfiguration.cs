using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseManagerDatabase.Entity.Configurations
{
    public class GroupConfiguration : IEntityTypeConfiguration<GroupRecord>
    {
        public void Configure(EntityTypeBuilder<GroupRecord> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(32);

            builder.
                HasOne(g => g.Teacher)
                .WithMany(t => t.Groups);

            builder.
                HasOne(g => g.Course)
                .WithMany(c => c.Groups)
                .HasForeignKey(g => g.CourseId);

            builder.
                HasMany(g => g.Students)
                .WithOne(s => s.Group)
                .HasForeignKey(s => s.GroupId);
        }
    }
}
