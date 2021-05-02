using System;
using System.Collections.Generic;

namespace MvcBlog.Models
{
    public partial class Tag
    {
        public Tag()
        {
            this.Posts = new List<Post>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}
