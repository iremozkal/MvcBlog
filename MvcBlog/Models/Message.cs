using System;
using System.Collections.Generic;

namespace MvcBlog.Models
{
    public partial class Message
    {
        public System.Guid SenderId { get; set; }
        public System.Guid RecieverId { get; set; }
        public string Message1 { get; set; }
        public System.DateTime Date { get; set; }
        public bool IsSeen { get; set; }
    }
}
