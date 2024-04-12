using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookStore_sag.Models;

namespace BookStore_sag.Controllers
{
    public class Book1Controller : Controller
    {
        private BooksContext db = new BooksContext();

        // GET: Book1
        public ActionResult Index()
        {
            return View(db.Students.ToList());
        }

        // GET: Book1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book1 book1 = db.Students.Find(id);
            if (book1 == null)
            {
                return HttpNotFound();
            }
            return View(book1);
        }

        // GET: Book1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Book1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Author,ISBN,Price")] Book1 book1)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(book1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(book1);
        }

        // GET: Book1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book1 book1 = db.Students.Find(id);
            if (book1 == null)
            {
                return HttpNotFound();
            }
            return View(book1);
        }

        // POST: Book1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Author,ISBN,Price")] Book1 book1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(book1);
        }

        // GET: Book1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book1 book1 = db.Students.Find(id);
            if (book1 == null)
            {
                return HttpNotFound();
            }
            return View(book1);
        }

        // POST: Book1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book1 book1 = db.Students.Find(id);
            db.Students.Remove(book1);
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
