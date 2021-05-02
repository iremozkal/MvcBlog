using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MvcBlog.Models.Mapping
{
    public class PostMap : EntityTypeConfiguration<Post>
    {
        public PostMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Body)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Post");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.Body).HasColumnName("Body");
            this.Property(t => t.PublishedAt).HasColumnName("PublishedAt");
            this.Property(t => t.CategoryId).HasColumnName("CategoryId");
            this.Property(t => t.ImageId).HasColumnName("ImageId");
            this.Property(t => t.AuthorId).HasColumnName("AuthorId");
            this.Property(t => t.ViewCount).HasColumnName("ViewCount");
            this.Property(t => t.LikeCount).HasColumnName("LikeCount");
            this.Property(t => t.IsActive).HasColumnName("IsActive");

            // Relationships
            this.HasMany(t => t.Tags)
                .WithMany(t => t.Posts)
                .Map(m =>
                    {
                        m.ToTable("PostTag");
                        m.MapLeftKey("PostId");
                        m.MapRightKey("TagId");
                    });

            this.HasRequired(t => t.Category)
                .WithMany(t => t.Posts)
                .HasForeignKey(d => d.CategoryId);
            this.HasRequired(t => t.Image)
                .WithMany(t => t.Posts)
                .HasForeignKey(d => d.ImageId);
            this.HasRequired(t => t.User)
                .WithMany(t => t.Posts)
                .HasForeignKey(d => d.AuthorId);

        }
    }
}
