using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DCyTICVideos;

namespace DCyTICVideos.Controllers
{
    public class FormatoesController : Controller
    {
        private VideosEntities db = new VideosEntities();

        // GET: Formatoes
        public ActionResult Index()
        {
            return View(db.Formatoes.ToList());
        }

        // GET: Formatoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Formato formato = db.Formatoes.Find(id);
            if (formato == null)
            {
                return HttpNotFound();
            }
            return View(formato);
        }

        // GET: Formatoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Formatoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_formato,formato1,estado")] Formato formato)
        {
            if (ModelState.IsValid)
            {
                db.Formatoes.Add(formato);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(formato);
        }

        // GET: Formatoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Formato formato = db.Formatoes.Find(id);
            if (formato == null)
            {
                return HttpNotFound();
            }
            return View(formato);
        }

        // POST: Formatoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_formato,formato1,estado")] Formato formato)
        {
            if (ModelState.IsValid)
            {
                db.Entry(formato).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(formato);
        }

        // GET: Formatoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Formato formato = db.Formatoes.Find(id);
            if (formato == null)
            {
                return HttpNotFound();
            }
            return View(formato);
        }

        // POST: Formatoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Formato formato = db.Formatoes.Find(id);
            db.Formatoes.Remove(formato);
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
