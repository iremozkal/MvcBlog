using System;
using System.Collections.Generic;

namespace MvcBlog.Models
{
    public partial class User
    {
        public User()
        {
            this.Comments = new List<Comment>();
            this.Images = new List<Image>();
            this.Posts = new List<Post>();
            this.SiteTrackings = new List<SiteTracking>();
        }

        public System.Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Mail { get; set; }
        public System.DateTime SavedAt { get; set; }
        public string Nickname { get; set; }
        public Nullable<int> ImageId { get; set; }
        public bool IsActive { get; set; }
        public bool IsAuthor { get; set; }
        public virtual aspnet_Users aspnet_Users { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual Image Image { get; set; }
        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<SiteTracking> SiteTrackings { get; set; }
    }
}
