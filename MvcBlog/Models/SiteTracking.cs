using System;
using System.Collections.Generic;

namespace MvcBlog.Models
{
    public partial class SiteTracking
    {
        public string Mail { get; set; }
        public Nullable<System.Guid> UserId { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual User User { get; set; }
    }
}
