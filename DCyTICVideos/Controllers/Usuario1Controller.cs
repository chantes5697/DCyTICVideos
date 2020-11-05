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
    public class Usuario1Controller : Controller
    {
        private VideosEntities db = new VideosEntities();

        // GET: Usuario1
        public ActionResult Index()
        {
            var usuario1 = db.Usuario1.Include(u => u.Rol1);
            return View(usuario1.ToList());
        }

        // GET: Usuario1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario1 usuario1 = db.Usuario1.Find(id);
            if (usuario1 == null)
            {
                return HttpNotFound();
            }
            return View(usuario1);
        }

        // GET: Usuario1/Create
        public ActionResult Create()
        {
            ViewBag.rol = new SelectList(db.Rols, "id_rol", "nombre");
            return View();
        }

        // POST: Usuario1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_usuario,username,rol,password")] Usuario1 usuario1)
        {
            if (ModelState.IsValid)
            {
                db.Usuario1.Add(usuario1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.rol = new SelectList(db.Rols, "id_rol", "nombre", usuario1.rol);
            return View(usuario1);
        }

        // GET: Usuario1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario1 usuario1 = db.Usuario1.Find(id);
            if (usuario1 == null)
            {
                return HttpNotFound();
            }
            ViewBag.rol = new SelectList(db.Rols, "id_rol", "nombre", usuario1.rol);
            return View(usuario1);
        }

        // POST: Usuario1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_usuario,username,rol,password")] Usuario1 usuario1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.rol = new SelectList(db.Rols, "id_rol", "nombre", usuario1.rol);
            return View(usuario1);
        }

        // GET: Usuario1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario1 usuario1 = db.Usuario1.Find(id);
            if (usuario1 == null)
            {
                return HttpNotFound();
            }
            return View(usuario1);
        }

        // POST: Usuario1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Usuario1 usuario1 = db.Usuario1.Find(id);
            db.Usuario1.Remove(usuario1);
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
