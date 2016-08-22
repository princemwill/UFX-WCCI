using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UFX_WCCI.Models;

namespace UFX_WCCI.Controllers
{
    public class AvatarFileController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: File
        public ActionResult Index(string id)
        {
            var fileToRetrieve = db.Users.Find(id);

            if (fileToRetrieve.PhotoBytes != null && fileToRetrieve.PhotoType != null)
                return File(fileToRetrieve.PhotoBytes, fileToRetrieve.PhotoType);

            return View();
        }
    }
}