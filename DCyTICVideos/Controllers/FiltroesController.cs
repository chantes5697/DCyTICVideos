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
    public class FiltroesController : Controller
    {
        private VideosEntities db = new VideosEntities();

        // GET: Filtroes
        public ActionResult Index()
        {
            var filtroes = db.Filtroes.Include(f => f.Video);
            return View(filtroes.ToList());
        }

        // GET: Filtroes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Filtro filtro = db.Filtroes.Find(id);
            if (filtro == null)
            {
                return HttpNotFound();
            }
            return View(filtro);
        }

        // GET: Filtroes/Create
        public ActionResult Create()
        {
            ViewBag.videos = new SelectList(db.Videos, "id_video", "contenido");
            return View();
        }

        // POST: Filtroes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_filtro,contenido,fecha,duracion,videos")] Filtro filtro)
        {
            if (ModelState.IsValid)
            {
                db.Filtroes.Add(filtro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.videos = new SelectList(db.Videos, "id_video", "contenido", filtro.videos);
            return View(filtro);
        }

        // GET: Filtroes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Filtro filtro = db.Filtroes.Find(id);
            if (filtro == null)
            {
                return HttpNotFound();
            }
            ViewBag.videos = new SelectList(db.Videos, "id_video", "contenido", filtro.videos);
            return View(filtro);
        }

        // POST: Filtroes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_filtro,contenido,fecha,duracion,videos")] Filtro filtro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(filtro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.videos = new SelectList(db.Videos, "id_video", "contenido", filtro.videos);
            return View(filtro);
        }

        // GET: Filtroes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Filtro filtro = db.Filtroes.Find(id);
            if (filtro == null)
            {
                return HttpNotFound();
            }
            return View(filtro);
        }

        // POST: Filtroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Filtro filtro = db.Filtroes.Find(id);
            db.Filtroes.Remove(filtro);
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
