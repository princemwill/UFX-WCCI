using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UFX_WCCI.Models;
using PagedList;

namespace UFX_WCCI.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationUser CurrentUser
        {

            get
            {
                UserManager<ApplicationUser> UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
                ApplicationUser currentUser = UserManager.FindById(User.Identity.GetUserId());
                return currentUser;
            }

        }
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index(int? page)
        {
            ViewBag.CurrentUser = CurrentUser;
            int pageSize = 6;
            int pageNumber = (page ?? 1);

            return View(db.Postings.ToPagedList(pageNumber, pageSize));
        }
       
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}