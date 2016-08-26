using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UFX_WCCI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace UFX_WCCI.Controllers
{
    public class PostingsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        private ApplicationUser CurrentUser
        {

        get
            {
                UserManager<ApplicationUser> UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
                ApplicationUser currentUser = UserManager.FindById(User.Identity.GetUserId());
                return currentUser;
            }

        }
        public ActionResult AddFollowing(string Id)
        {
            ApplicationUser user = db.Users.Find(Id);
            ApplicationUser loggedInUser = CurrentUser;
            loggedInUser.Following.Add(user);

            return RedirectToAction("UserProfile", user);
        }

        public ActionResult DeleteFollowing(string Id)
        {
            ApplicationUser user = db.Users.Find(Id);
            ApplicationUser loggedInUser = CurrentUser;
            loggedInUser.Following.Remove(user);

            return RedirectToAction("UserProfile", user);
        }
        public ActionResult UserProfile(string Id)
        {
            ApplicationUser user = db.Users.Find(Id);

            return View(user);
            //return RedirectToAction("Profile", user);
        }

        public ActionResult PostsMap()
        {
            ViewBag.CurrentUser = CurrentUser;
            return View(db.Users.ToList());
        }

        // GET: Postings
        public ActionResult Index()
        {
            ViewBag.CurrentUser = CurrentUser;
            return View(db.Postings.ToList());
        }

        // GET: Postings/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Posting posting = db.Postings.Find(id);
        //    if (posting == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(posting);
        //}

        // GET: Postings/Create
        public ActionResult Create()
        {
            if (CurrentUser != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // POST: Postings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PostingID,Price,Desc,Quantity")] Posting posting, HttpPostedFileBase upload)
        {
            posting.AppUser = CurrentUser;
            posting.PostingTime = DateTime.Now;
            CurrentUser.Posts.Add(posting);

            if (ModelState.IsValid)
            {
                if (upload != null && upload.ContentLength > 0)
                {
                    // save the three part field for the picture chosen by user
                    posting.PhotoName = System.IO.Path.GetFileName(upload.FileName);
                    posting.FileTypePost = FileTypePost.PicPost;
                    posting.PhotoType = upload.ContentType;

                    using (var reader = new System.IO.BinaryReader(upload.InputStream))
                    {
                        posting.PhotoBytes = reader.ReadBytes(upload.ContentLength);
                    }

                }
                //save posting to the database
                db.Postings.Add(posting);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(posting);
        }

        // GET: Postings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Posting posting = db.Postings.Find(id);
            if (posting == null)
            {
                return HttpNotFound();
            }
            return View(posting);
        }

        // POST: Postings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PostingID,Price,Desc,Quantity,PostingTime")] Posting posting, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                if (upload != null && upload.ContentLength > 0)
                {
                    var avatar = new Posting
                    {
                        PhotoName = System.IO.Path.GetFileName(upload.FileName),
                        FileTypePost = FileTypePost.PicPost,
                        PhotoType = upload.ContentType
                    };
                    using (var reader = new System.IO.BinaryReader(upload.InputStream))
                    {
                        avatar.PhotoBytes = reader.ReadBytes(upload.ContentLength);
                    }

                    posting.PhotoName = avatar.PhotoName;
                    posting.FileTypePost = avatar.FileTypePost;
                    posting.PhotoType = avatar.PhotoType;
                    posting.PhotoBytes = avatar.PhotoBytes;
                }
                db.Entry(posting).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(posting);
        }

        // GET: Postings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Posting posting = db.Postings.Find(id);
            if (posting == null)
            {
                return HttpNotFound();
            }
            return View(posting);
        }

        // POST: Postings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Posting posting = db.Postings.Find(id);
            db.Postings.Remove(posting);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
