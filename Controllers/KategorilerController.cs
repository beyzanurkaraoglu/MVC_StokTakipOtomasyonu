using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_StokTakipOtomasyonu.Models.Entity;

namespace MVC_StokTakipOtomasyonu.Controllers
{
    public class KategorilerController : Controller
    {
        MVC_StokTakipEntities db = new MVC_StokTakipEntities();
        public ActionResult Index()
        {
            return View(db.Kategoriler.ToList());



        }
        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Ekle(Kategoriler p)

        {
            db.Kategoriler.Add(p);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult SilBilgiGetir(int id)
        {
            Kategoriler silinecekKategori = db.Kategoriler.Find(id);
            db.Kategoriler.Remove(silinecekKategori);
            db.SaveChanges();
            
           

            return RedirectToAction("Index"); //buluduğun controllerdaki methoda git.
        } public ActionResult GuncelleBilgiGetir(Kategoriler p)
        {
            var model = db.Kategoriler.Find(p.ID);
            if (model == null) return HttpNotFound();
           
            return View(model);

        }
        public ActionResult Guncelle(Kategoriler p)
        {
            db.Entry(p).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}