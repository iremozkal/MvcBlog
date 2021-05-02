using System;
using System.Collections.Generic;

namespace MvcBlog.Models
{
    public partial class Category
    {
        public Category()
        {
            this.Posts = new List<Post>();
            this.SiteTrackings = new List<SiteTracking>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<SiteTracking> SiteTrackings { get; set; }
    }
}
