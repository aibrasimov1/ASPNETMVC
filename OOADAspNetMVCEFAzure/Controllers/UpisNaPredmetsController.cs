using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OOADAspNetMVCEFAzure.Models;

namespace OOADAspNetMVCEFAzure.Controllers
{
    [Authorize]
    public class UpisNaPredmetsController : Controller
    {
        private OOADContext db = new OOADContext();

        // GET: UpisNaPredmets
        public ActionResult Index()
        {
            var upisNaPredmet = db.UpisNaPredmet.Include(u => u.Predmet).Include(u => u.Student);
            return View(upisNaPredmet.ToList());
        }

        // GET: UpisNaPredmets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UpisNaPredmet upisNaPredmet = db.UpisNaPredmet.Find(id);
            if (upisNaPredmet == null)
            {
                return HttpNotFound();
            }
            return View(upisNaPredmet);
        }

        // GET: UpisNaPredmets/Create
        public ActionResult Create()
        {
            ViewBag.PredmetId = new SelectList(db.Predmet, "PredmetId", "Naziv");
            ViewBag.StudentId = new SelectList(db.Student, "ID", "ImePrezime");
            return View();
        }

        // POST: UpisNaPredmets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UpisNaPredmetId,PredmetId,StudentId,Ocjena")] UpisNaPredmet upisNaPredmet)
        {
            if (ModelState.IsValid)
            {
                db.UpisNaPredmet.Add(upisNaPredmet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PredmetId = new SelectList(db.Predmet, "PredmetId", "Naziv", upisNaPredmet.PredmetId);
            ViewBag.StudentId = new SelectList(db.Student, "ID", "Ime", upisNaPredmet.StudentId);
            return View(upisNaPredmet);
        }

        // GET: UpisNaPredmets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UpisNaPredmet upisNaPredmet = db.UpisNaPredmet.Find(id);
            if (upisNaPredmet == null)
            {
                return HttpNotFound();
            }
            ViewBag.PredmetId = new SelectList(db.Predmet, "PredmetId", "Naziv", upisNaPredmet.PredmetId);
            ViewBag.StudentId = new SelectList(db.Student, "ID", "Ime", upisNaPredmet.StudentId);
            return View(upisNaPredmet);
        }

        // POST: UpisNaPredmets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UpisNaPredmetId,PredmetId,StudentId,Ocjena")] UpisNaPredmet upisNaPredmet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(upisNaPredmet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PredmetId = new SelectList(db.Predmet, "PredmetId", "Naziv", upisNaPredmet.PredmetId);
            ViewBag.StudentId = new SelectList(db.Student, "ID", "Ime", upisNaPredmet.StudentId);
            return View(upisNaPredmet);
        }

        // GET: UpisNaPredmets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UpisNaPredmet upisNaPredmet = db.UpisNaPredmet.Find(id);
            if (upisNaPredmet == null)
            {
                return HttpNotFound();
            }
            return View(upisNaPredmet);
        }

        // POST: UpisNaPredmets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UpisNaPredmet upisNaPredmet = db.UpisNaPredmet.Find(id);
            db.UpisNaPredmet.Remove(upisNaPredmet);
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
