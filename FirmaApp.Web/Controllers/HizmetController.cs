using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FirmaApp.Model;

namespace FirmaApp.Web.Controllers
{
    public class HizmetController : Controller
    {
        // GET: Hizmet
        public ActionResult Index()
        {
            FirmaContext db = new FirmaContext();
            int firmaID = (int)((Kullanici)Session["Kullanici"]).firmaID;
            return View(db.Hizmet.Where(x => x.firmaID == firmaID).ToList());
        }
        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(Hizmet h)
        {
            h.firmaID = ((Kullanici)Session["Kullanici"]).firmaID;
            FirmaContext db = new FirmaContext();
            db.Hizmet.Add(h);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            FirmaContext db = new FirmaContext();
            Hizmet h = db.Hizmet.Where(x => x.hizmetID == id).FirstOrDefault();
            if (h != null)
            {
                db.Hizmet.Remove(h);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Duzenle(int id)
        {
            TempData["hizmetID"] = id;
            FirmaContext db = new FirmaContext();
            Hizmet hizmet = db.Hizmet.Where(x => x.hizmetID == id).FirstOrDefault();
            return View(hizmet);
        }

        [HttpPost]
        public ActionResult Duzenle(Hizmet h)
        {
            int hizmetID = TempData["hizmetID"] == null ? 0 : (int)TempData["hizmetID"];
            //if (TempData["kullaniciID"] == null)
            //    kullaniciID = 0;
            //else
            //    kullaniciID = (int)TempData["kullaniciID"];

            FirmaContext db = new FirmaContext();
            Hizmet hizmet = db.Hizmet.Where(x => x.hizmetID == hizmetID).FirstOrDefault();
            if (hizmet != null)
            {
                hizmet.ad = h.ad;
                db.SaveChanges();
            }

            return RedirectToAction("Index");

        }
    }
}