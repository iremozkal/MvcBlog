using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MvcBlog.Models.Mapping
{
    public class MessageMap : EntityTypeConfiguration<Message>
    {
        public MessageMap()
        {
            // Primary Key
            this.HasKey(t => new { t.SenderId, t.RecieverId, t.Message1, t.Date, t.IsSeen });

            // Properties
            this.Property(t => t.Message1)
                .IsRequired()
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("Messages");
            this.Property(t => t.SenderId).HasColumnName("SenderId");
            this.Property(t => t.RecieverId).HasColumnName("RecieverId");
            this.Property(t => t.Message1).HasColumnName("Message");
            this.Property(t => t.Date).HasColumnName("Date");
            this.Property(t => t.IsSeen).HasColumnName("IsSeen");
        }
    }
}
