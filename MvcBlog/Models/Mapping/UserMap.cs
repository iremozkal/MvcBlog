using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MvcBlog.Models.Mapping
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Surname)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Mail)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.Nickname)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("User");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Surname).HasColumnName("Surname");
            this.Property(t => t.Mail).HasColumnName("Mail");
            this.Property(t => t.SavedAt).HasColumnName("SavedAt");
            this.Property(t => t.Nickname).HasColumnName("Nickname");
            this.Property(t => t.ImageId).HasColumnName("ImageId");
            this.Property(t => t.IsActive).HasColumnName("IsActive");
            this.Property(t => t.IsAuthor).HasColumnName("IsAuthor");

            // Relationships
            this.HasOptional(t => t.Image)
                .WithMany(t => t.Users)
                .HasForeignKey(d => d.ImageId);

        }
    }
}
