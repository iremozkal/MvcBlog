using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MvcBlog.Models.Mapping
{
    public class ImageMap : EntityTypeConfiguration<Image>
    {
        public ImageMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.PathSmallImage)
                .IsRequired()
                .HasMaxLength(500);

            this.Property(t => t.PathMediumImage)
                .IsRequired()
                .HasMaxLength(500);

            this.Property(t => t.PathLargeImage)
                .IsRequired()
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("Image");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.PathSmallImage).HasColumnName("PathSmallImage");
            this.Property(t => t.PathMediumImage).HasColumnName("PathMediumImage");
            this.Property(t => t.PathLargeImage).HasColumnName("PathLargeImage");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.AddedAt).HasColumnName("AddedAt");
            this.Property(t => t.ViewCount).HasColumnName("ViewCount");
            this.Property(t => t.LikeCount).HasColumnName("LikeCount");
            this.Property(t => t.IsActive).HasColumnName("IsActive");

            // Relationships
            this.HasMany(t => t.Posts1)
                .WithMany(t => t.Images)
                .Map(m =>
                    {
                        m.ToTable("PostImage");
                        m.MapLeftKey("ImageId");
                        m.MapRightKey("PostId");
                    });

            this.HasRequired(t => t.User)
                .WithMany(t => t.Images)
                .HasForeignKey(d => d.UserId);

        }
    }
}
