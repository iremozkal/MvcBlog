using System;
using System.Collections.Generic;

namespace MvcBlog.Models
{
    public partial class VisitorIPLog
    {
        public string IPAddress { get; set; }
        public System.DateTime Date { get; set; }
    }
}
