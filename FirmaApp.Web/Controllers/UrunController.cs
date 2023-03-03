using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FirmaApp.Model;

namespace FirmaApp.Web.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        public ActionResult Index()
        {

            FirmaContext db = new FirmaContext();
            int firmaID = (int)((Kullanici)Session["Kullanici"]).firmaID;
            return View(db.Urun.Where(x => x.firmaID == firmaID).ToList());

        }
        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }
        public ActionResult Sil(int id)
        {
            FirmaContext db = new FirmaContext();
            Urun u = db.Urun.Where(x => x.urunID == id).FirstOrDefault();
            if (u != null)
            {
                db.Urun.Remove(u);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Ekle(Urun u)
        {

            u.firmaID = ((Kullanici)Session["Kullanici"]).firmaID;
            FirmaContext db = new FirmaContext();
            db.Urun.Add(u);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Duzenle(int id)
        {
            TempData["urunID"] = id;
            FirmaContext db = new FirmaContext();
            Urun urun = db.Urun.Where(x => x.urunID == id).FirstOrDefault();
            return View(urun);
        }

        [HttpPost]
        public ActionResult Duzenle(Urun u)
        {
            int urunID = TempData["urunID"] == null ? 0 : (int)TempData["urunID"];
            //if (TempData["kullaniciID"] == null)
            //    kullaniciID = 0;
            //else
            //    kullaniciID = (int)TempData["kullaniciID"];

            FirmaContext db = new FirmaContext();
            Urun urun = db.Urun.Where(x => x.urunID == urunID).FirstOrDefault();
            if (urun != null)
            {
               urun.ad = u.ad;
                urun.detay = u.detay;
                urun.ozet = u.ozet;
                urun.aktifMI = u.aktifMI;

                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}