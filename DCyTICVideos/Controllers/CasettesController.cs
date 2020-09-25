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
    public class CasettesController : Controller
    {
        private VideosEntities db = new VideosEntities();

        // GET: Casettes
        public ActionResult Index()
        {
            var casettes = db.Casettes.Include(c => c.Formato1);
            return View(casettes.ToList());
        }

        // GET: Casettes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Casette casette = db.Casettes.Find(id);
            if (casette == null)
            {
                return HttpNotFound();
            }
            return View(casette);
        }

        // GET: Casettes/Create
        public ActionResult Create()
        {
            ViewBag.formato = new SelectList(db.Formatoes, "id_formato", "formato1");
            return View();
        }

        // POST: Casettes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_casette,clave,estado,formato")] Casette casette)
        {
            if (ModelState.IsValid)
            {
                db.Casettes.Add(casette);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.formato = new SelectList(db.Formatoes, "id_formato", "formato1", casette.formato);
            return View(casette);
        }

        // GET: Casettes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Casette casette = db.Casettes.Find(id);
            if (casette == null)
            {
                return HttpNotFound();
            }
            ViewBag.formato = new SelectList(db.Formatoes, "id_formato", "formato1", casette.formato);
            return View(casette);
        }

        // POST: Casettes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_casette,clave,estado,formato")] Casette casette)
        {
            if (ModelState.IsValid)
            {
                db.Entry(casette).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.formato = new SelectList(db.Formatoes, "id_formato", "formato1", casette.formato);
            return View(casette);
        }

        // GET: Casettes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Casette casette = db.Casettes.Find(id);
            if (casette == null)
            {
                return HttpNotFound();
            }
            return View(casette);
        }

        // POST: Casettes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Casette casette = db.Casettes.Find(id);
            db.Casettes.Remove(casette);
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
