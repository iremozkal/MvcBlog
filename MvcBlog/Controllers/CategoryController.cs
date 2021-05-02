using MvcBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlog.Controllers
{
    public class CategoryController : Controller
    {
        //
        // GET: /Category/

        BlogDBContext blogDbContext = new BlogDBContext();

        public ActionResult Index(int id)
        {
            return View(id);
        }

        public ActionResult ListPosts(int id)
        {
            var data = blogDbContext.Posts.Where(p => p.CategoryId == id);
            return View("ListPosts", data);
        }
    }
}
