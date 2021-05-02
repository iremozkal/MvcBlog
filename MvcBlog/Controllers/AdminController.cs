using MvcBlog.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlog.Controllers
{
    using Models;

    [Authorize(Roles = "Admin, Author")]
    public class AdminController : Controller
    {
        //
        // GET: /Admin/
        BlogDBContext blogDbContext = new BlogDBContext();

        public ActionResult Index()
        {
            ViewBag.UserType = 1;

            return View(blogDbContext.Posts.ToList());
        }

        public ActionResult WritePost()
        {
            ViewBag.UserType = 1;
            ViewBag.Categories = blogDbContext.Categories.ToList();

            return View();
        }

        [HttpPost]
        public ActionResult WritePost(Post post, HttpPostedFileBase Image, string Tags)
        {
            if (post != null)
            {
                MvcBlog.Models.User activeUser = Session["User"] as MvcBlog.Models.User;
                post.PublishedAt = DateTime.Now;
                post.AuthorId = activeUser.Id;
                post.ImageId = SaveImage(Image, HttpContext);

                blogDbContext.Posts.Add(post);
                blogDbContext.SaveChanges();

                string[] tags = Tags.Split(',');
                foreach (string str in tags)
                {
                    Tag tag = blogDbContext.Tags.FirstOrDefault(t => t.Name.ToLower() == str.ToLower().Trim());
                    if (tag == null)
                    {
                        tag = new Tag();
                        tag.Name = str;
                        blogDbContext.Tags.Add(tag);
                        blogDbContext.SaveChanges();
                    }
                    post.Tags.Add(tag);
                    blogDbContext.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }

        public static int SaveImage(HttpPostedFileBase Image, HttpContextBase ctx)
        {
            BlogDBContext blogDbContext = new BlogDBContext();

            int smallWidth = Convert.ToInt32(ConfigurationManager.AppSettings["smallWidth"]);
            int smallHeight = Convert.ToInt32(ConfigurationManager.AppSettings["smallHeight"]);
            int mediumWidth = Convert.ToInt32(ConfigurationManager.AppSettings["mediumWidth"]);
            int mediumHeight = Convert.ToInt32(ConfigurationManager.AppSettings["mediumHeight"]);
            int largeWidth = Convert.ToInt32(ConfigurationManager.AppSettings["largeWidth"]);
            int largeHeight = Convert.ToInt32(ConfigurationManager.AppSettings["largeHeight"]);

            string newImgName = Path.GetFileNameWithoutExtension(Image.FileName)
                + "-" + Guid.NewGuid() + Path.GetExtension(Image.FileName);

            System.Drawing.Image orijinalImage = System.Drawing.Image.FromStream(Image.InputStream);

            Bitmap smallImage = new Bitmap(orijinalImage, smallWidth, smallHeight);
            Bitmap mediumImage = new Bitmap(orijinalImage, mediumWidth, mediumHeight);
            Bitmap largeImage = new Bitmap(orijinalImage);

            string smallPath = "/Content/images/small/" + newImgName;
            string mediumPath = "/Content/images/medium/" + newImgName;
            string largePath = "/Content/images/large/" + newImgName;

            smallImage.Save(ctx.Server.MapPath("~" + smallPath));
            mediumImage.Save(ctx.Server.MapPath("~" + mediumPath));
            largeImage.Save(ctx.Server.MapPath("~" + largePath));

            MvcBlog.Models.User activeUser = ctx.Session["User"] as MvcBlog.Models.User;
            MvcBlog.Models.Image dbImage = new MvcBlog.Models.Image();

            dbImage.Title = Image.FileName;
            dbImage.PathSmallImage = smallPath;
            dbImage.PathMediumImage = mediumPath;
            dbImage.PathLargeImage = largePath;
            dbImage.AddedAt = DateTime.Now;
            dbImage.UserId = activeUser.Id;

            blogDbContext.Images.Add(dbImage);
            blogDbContext.SaveChanges();

            return dbImage.Id;
        }

        public ActionResult Category()
        {
            ViewBag.UserType = 1;

            return View(blogDbContext.Categories.ToList());
        }

        public ActionResult AddCategory()
        {
            ViewBag.UserType = 1;

            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            blogDbContext.Categories.Add(category);
            blogDbContext.SaveChanges();

            return RedirectToAction("Category");
        }

        public ActionResult EditCategory(int id)
        {
            ViewBag.UserType = 1;

            return View(blogDbContext.Categories.FirstOrDefault(c => c.Id == id));
        }

        [HttpPost]
        public ActionResult EditCategory(Category category)
        {
            blogDbContext.Entry(category).State = System.Data.EntityState.Modified;
            blogDbContext.SaveChanges();

            return RedirectToAction("Category");
        }

        public ActionResult DeleteCategory(int id)
        {
            ViewBag.UserType = 1;
            blogDbContext.Categories.Remove(blogDbContext.Categories.FirstOrDefault(c => c.Id == id));
            blogDbContext.SaveChanges();

            return RedirectToAction("Category");
        }

        // [Authorize(Roles="Admin")]
        // public ActionResult Role()
        // {
        //      return View();
        // }
    }
}
