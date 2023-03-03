using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FirmaApp.Model;


namespace FirmaApp.Web.Controllers
{
    public class AdresController : Controller
    {
        public ActionResult Index()
        {

            FirmaContext db = new FirmaContext();
            int firmaID = (int)((Kullanici)Session["Kullanici"]).firmaID;
            return View(db.Adres.Where(x => x.firmaID == firmaID).ToList());

        }
        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }
        public ActionResult Sil(int id)
        {
            FirmaContext db = new FirmaContext();
            Adres a = db.Adres.Where(x => x.adresID == id).FirstOrDefault();
            if (a != null)
            {
                db.Adres.Remove(a);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Ekle(Adres a)
        {

            a.firmaID = ((Kullanici)Session["Kullanici"]).firmaID;
            FirmaContext db = new FirmaContext();
            db.Adres.Add(a);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Duzenle(int id)
        {
            TempData["AdresID"] = id;
            FirmaContext db = new FirmaContext();
            Adres Adres = db.Adres.Where(x => x.adresID == id).FirstOrDefault();
            return View(Adres);
        }

        [HttpPost]
        public ActionResult Duzenle(Adres u)
        {
            int AdresID = TempData["AdresID"] == null ? 0 : (int)TempData["AdresID"];
            //if (TempData["kullaniciID"] == null)
            //    kullaniciID = 0;
            //else
            //    kullaniciID = (int)TempData["kullaniciID"];

            FirmaContext db = new FirmaContext();
            Adres adres = db.Adres.Where(x => x.adresID == AdresID).FirstOrDefault();
            if (adres != null)
            {
                
                adres.detay = u.detay;
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}