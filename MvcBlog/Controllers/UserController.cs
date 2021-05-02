using MvcBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Data.Entity.Validation;

namespace MvcBlog.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/
        BlogDBContext blogDbContext = new BlogDBContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(MvcBlog.Models.User user, HttpPostedFileBase Image, string password)
        {
            try
            {
                MembershipUser memberUser = Membership.CreateUser(user.Nickname, password, user.Mail);
                user.Id = (Guid)(memberUser.ProviderUserKey);
                Session["User"] = user;
                user.ImageId = AdminController.SaveImage(Image, HttpContext);
                user.SavedAt = DateTime.Now;
                blogDbContext.Users.Add(user);
                blogDbContext.SaveChanges();

                FormsAuthentication.RedirectFromLoginPage(user.Nickname, true);
                Session["User"] = user;
            }
            catch (DbEntityValidationException)
            {
                throw;
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string Nickname, string Password)
        {
            if (Membership.ValidateUser(Nickname, Password))
            {
                FormsAuthentication.RedirectFromLoginPage(Nickname, true);
                Guid id = (Guid)Membership.GetUser(Nickname).ProviderUserKey;
                Session["User"] = blogDbContext.Users.FirstOrDefault(u => u.Id == id);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Message = "Username or password is wrong!";
                return View();
            }
        }
    }
}
