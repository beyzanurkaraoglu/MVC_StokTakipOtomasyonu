using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_StokTakipOtomasyonu.Models.Entity;


namespace MVC_StokTakipOtomasyonu.Controllers
{
    public class BirimlerController : Controller
    {
        MVC_StokTakipEntities db = new MVC_StokTakipEntities();
        public ActionResult Index()
        {

            return View(db.Birimler.ToList());
        }[HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }[HttpPost]
        public ActionResult Ekle(Birimler p)
        {
            db.Birimler.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SilBilgiGetir(int? id)
        {
            var silinecekBirim = db.Birimler.Find(id);
            db.Birimler.Remove(silinecekBirim);
            db.SaveChanges();
            //db.Birimler.FirstOrDefault(x => x.ID == id); linq sorgu örneği
            return View();

        }

    }
}
