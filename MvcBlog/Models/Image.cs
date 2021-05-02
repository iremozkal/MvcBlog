using System;
using System.Collections.Generic;

namespace MvcBlog.Models
{
    public partial class Image
    {
        public Image()
        {
            this.Users = new List<User>();
            this.Posts = new List<Post>();
            this.Posts1 = new List<Post>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string PathSmallImage { get; set; }
        public string PathMediumImage { get; set; }
        public string PathLargeImage { get; set; }
        public System.Guid UserId { get; set; }
        public System.DateTime AddedAt { get; set; }
        public int ViewCount { get; set; }
        public int LikeCount { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Post> Posts1 { get; set; }
    }
}
