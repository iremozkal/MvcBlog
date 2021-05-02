using System;
using System.Collections.Generic;

namespace MvcBlog.Models
{
    public partial class Comment
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public int PostId { get; set; }
        public System.DateTime AddedAt { get; set; }
        public System.Guid AuthorId { get; set; }
        public bool IsActive { get; set; }
        public virtual Post Post { get; set; }
        public virtual User User { get; set; }
    }
}
