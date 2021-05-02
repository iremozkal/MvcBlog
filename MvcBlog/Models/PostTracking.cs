using System;
using System.Collections.Generic;

namespace MvcBlog.Models
{
    public partial class PostTracking
    {
        public int PostId { get; set; }
        public System.Guid UserId { get; set; }
        public virtual Post Post { get; set; }
    }
}
