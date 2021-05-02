using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MvcBlog.Models.Mapping
{
    public class VisitorIPLogMap : EntityTypeConfiguration<VisitorIPLog>
    {
        public VisitorIPLogMap()
        {
            // Primary Key
            this.HasKey(t => new { t.IPAddress, t.Date });

            // Properties
            this.Property(t => t.IPAddress)
                .IsRequired()
                .HasMaxLength(15);

            // Table & Column Mappings
            this.ToTable("VisitorIPLog");
            this.Property(t => t.IPAddress).HasColumnName("IPAddress");
            this.Property(t => t.Date).HasColumnName("Date");
        }
    }
}
