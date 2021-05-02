using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MvcBlog.Models.Mapping
{
    public class PostTrackingMap : EntityTypeConfiguration<PostTracking>
    {
        public PostTrackingMap()
        {
            // Primary Key
            this.HasKey(t => new { t.PostId, t.UserId });

            // Properties
            this.Property(t => t.PostId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("PostTracking");
            this.Property(t => t.PostId).HasColumnName("PostId");
            this.Property(t => t.UserId).HasColumnName("UserId");

            // Relationships
            this.HasRequired(t => t.Post)
                .WithMany(t => t.PostTrackings)
                .HasForeignKey(d => d.PostId);

        }
    }
}
