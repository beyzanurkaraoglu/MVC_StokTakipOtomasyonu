using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_StokTakipOtomasyonu.Models.Entity;

namespace MVC_StokTakipOtomasyonu.Controllers
{
    public class MarkalarsController : Controller
    {
        private MVC_StokTakipEntities db = new MVC_StokTakipEntities();

        // GET: Markalars
        public ActionResult Index()
        {
            var markalar = db.Markalar.Include(m => m.Kategoriler);
            return View(markalar.ToList());
        }

        // GET: Markalars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Markalar markalar = db.Markalar.Find(id);
            if (markalar == null)
            {
                return HttpNotFound();
            }
            return View(markalar);
        }

        // GET: Markalars/Create
        public ActionResult Create()
        {
            ViewBag.KategoriID = new SelectList(db.Kategoriler, "ID", "Kategori");
            return View();
        }

        // POST: Markalars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,KategoriID,Marka,Açıklama")] Markalar markalar)
        {
            if (ModelState.IsValid)
            {
                db.Markalar.Add(markalar);
                db.SaveChanges();
                return RedirectToAction("Index");
                //CRUD yappısı
            }

            ViewBag.KategoriID = new SelectList(db.Kategoriler, "ID", "Kategori", markalar.KategoriID);
            return View(markalar);
        }

        // GET: Markalars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Markalar markalar = db.Markalar.Find(id);
            if (markalar == null)
            {
                return HttpNotFound();
            }
            ViewBag.KategoriID = new SelectList(db.Kategoriler, "ID", "Kategori", markalar.KategoriID);
            return View(markalar);
        }

        // POST: Markalars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,KategoriID,Marka,Açıklama")] Markalar markalar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(markalar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KategoriID = new SelectList(db.Kategoriler, "ID", "Kategori", markalar.KategoriID);
            return View(markalar);
        }

        // GET: Markalars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Markalar markalar = db.Markalar.Find(id);
            if (markalar == null)
            {
                return HttpNotFound();
            }
            return View(markalar);
        }

        // POST: Markalars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Markalar markalar = db.Markalar.Find(id);
            db.Markalar.Remove(markalar);
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
