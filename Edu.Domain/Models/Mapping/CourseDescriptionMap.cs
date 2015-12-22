using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Edu.Domain.Models.Mapping
{
    public class CourseDescriptionMap : EntityTypeConfiguration<CourseDescription>
    {
        public CourseDescriptionMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("CourseDescription");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.ShortDescription).HasColumnName("ShortDescription");
            this.Property(t => t.LongDescription).HasColumnName("LongDescription");
            this.Property(t => t.CourseLength).HasColumnName("CourseLength");

            // Relationships
            this.HasRequired(t => t.Course)
                .WithOptional(t => t.CourseDescription);

        }
    }
}
