using System;
using System.Collections.Generic;

namespace MvcBlog.Models
{
    public partial class Post
    {
        public Post()
        {
            this.Comments = new List<Comment>();
            this.PostTrackings = new List<PostTracking>();
            this.Images = new List<Image>();
            this.Tags = new List<Tag>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public System.DateTime PublishedAt { get; set; }
        public int CategoryId { get; set; }
        public int ImageId { get; set; }
        public System.Guid AuthorId { get; set; }
        public int ViewCount { get; set; }
        public int LikeCount { get; set; }
        public bool IsActive { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual Image Image { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<PostTracking> PostTrackings { get; set; }
        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
    }
}
