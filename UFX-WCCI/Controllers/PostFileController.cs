using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UFX_WCCI.Models;

namespace UFX_WCCI.Controllers
{
    public class PostFileController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: File
        public ActionResult Index(int id)
        {
            var fileToRetrieve = db.Postings.Find(id);

            if (fileToRetrieve.PhotoBytes != null && fileToRetrieve.PhotoType != null)
                return File(fileToRetrieve.PhotoBytes, fileToRetrieve.PhotoType);

            return View();
        }
    }
}