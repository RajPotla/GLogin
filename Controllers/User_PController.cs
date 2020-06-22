using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GLogin.Models;

namespace GLogin.Controllers
{
    public class User_PController : Controller
    {
        private GlassdoorEntities db = new GlassdoorEntities();

        // GET: User_P
        public ActionResult Index()
        {
            return View(db.User_P.ToList());
        }

        // GET: User_P/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_P user_P = db.User_P.Find(id);
            if (user_P == null)
            {
                return HttpNotFound();
            }
            return View(user_P);
        }

        // GET: User_P/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User_P/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "User_ID,First_Name,Last_Name,E_mail,Phone_Number,date_created,Password")] User_P user_P)
        {
            if (ModelState.IsValid)
            {
                db.User_P.Add(user_P);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user_P);
        }

        // GET: User_P/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_P user_P = db.User_P.Find(id);
            if (user_P == null)
            {
                return HttpNotFound();
            }
            return View(user_P);
        }

        // POST: User_P/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "User_ID,First_Name,Last_Name,E_mail,Phone_Number,date_created,Password")] User_P user_P)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user_P).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user_P);
        }

        // GET: User_P/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_P user_P = db.User_P.Find(id);
            if (user_P == null)
            {
                return HttpNotFound();
            }
            return View(user_P);
        }

        // POST: User_P/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User_P user_P = db.User_P.Find(id);
            db.User_P.Remove(user_P);
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
