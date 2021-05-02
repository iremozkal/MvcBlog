using MvcBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlog.Controllers
{
    public class PostController : Controller
    {
        //
        // GET: /Post/

        BlogDBContext blogDbContext = new BlogDBContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListPosts(int year = 0, int month = 0)
        {
            var data = blogDbContext.Posts.Where(p => p.PublishedAt.Year == year && p.PublishedAt.Month == month);

            return View("ListPosts", data);
        }

        public ActionResult ListByDate(int year, int month)
        {
            ViewBag.year = year;
            ViewBag.month = month;

            return View();
        }

        public ActionResult Detail(int id)
        {
            ViewBag.User = Session["User"];
            Post post = blogDbContext.Posts.FirstOrDefault(p => p.Id == id);
            // for direct increase on view count when the page is load
            // post.ViewCount++;
            // blogDbContext.SaveChanges();

            return View(post);
        }

        [HttpPost]
        public ActionResult WriteComment(Comment comment)
        {
            comment.AddedAt = DateTime.Now;
            comment.Title = "";
            comment.IsActive = false;
            blogDbContext.Comments.Add(comment);
            blogDbContext.SaveChanges();

            return RedirectToAction("Detail", new { id = comment.PostId });
        }

        public string Like(int id)
        {
            Post post = blogDbContext.Posts.FirstOrDefault(p => p.Id == id);
            post.LikeCount++;
            blogDbContext.SaveChanges();

            return post.LikeCount.ToString(); ;
        }

        public void Seen(int id)
        {
            Post post = blogDbContext.Posts.FirstOrDefault(p => p.Id == id);
            post.ViewCount++;
            blogDbContext.SaveChanges();
        }
    }
}
