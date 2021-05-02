using MvcBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlog.Controllers
{
    public class AuthorController : Controller
    {
        //
        // GET: /Author/

        BlogDBContext blogDbContext = new BlogDBContext();

        public ActionResult Index(Guid id)
        {
            return View(id);
        }

        public ActionResult ListPosts(Guid id)
        {
            var data = blogDbContext.Posts.Where(p => p.AuthorId == id);
            return View("ListPosts", data);
        }
    }
}
