using MvcBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlog.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        BlogDBContext blogDbContext = new BlogDBContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CategoryWidget()
        {
            var categorylist = blogDbContext.Categories.ToList();

            return View(categorylist);
        }

        public ActionResult PostWidget()
        {
            ViewBag.Fresh = blogDbContext.Posts.OrderByDescending(p => p.PublishedAt).Take(3);
            ViewBag.Popular = blogDbContext.Posts.OrderByDescending(p => p.ViewCount).Take(3);

            return View();
        }

        public ActionResult TagWidget()
        {
            var taglist = blogDbContext.Tags.ToList();

            return View(taglist);
        }

        public ActionResult ListPosts()
        {
            return View();
        }

        public ActionResult GetAllPosts()
        {
            var posts = blogDbContext.Posts.ToList();

            return View("ListPosts", posts);
        }
    }
}
