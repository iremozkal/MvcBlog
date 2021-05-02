using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MvcBlog.Models.Mapping
{
    public class SiteTrackingMap : EntityTypeConfiguration<SiteTracking>
    {
        public SiteTrackingMap()
        {
            // Primary Key
            this.HasKey(t => t.Mail);

            // Properties
            this.Property(t => t.Mail)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("SiteTracking");
            this.Property(t => t.Mail).HasColumnName("Mail");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.CategoryId).HasColumnName("CategoryId");

            // Relationships
            this.HasOptional(t => t.Category)
                .WithMany(t => t.SiteTrackings)
                .HasForeignKey(d => d.CategoryId);
            this.HasOptional(t => t.User)
                .WithMany(t => t.SiteTrackings)
                .HasForeignKey(d => d.UserId);

        }
    }
}
