using FirmaApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirmaApp.Web.Controllers
{
    public class ReferansController : Controller
    {
        // GET: Referans
        public ActionResult Index()
        {
            FirmaContext db = new FirmaContext();
            int firmaID = (int)((Kullanici)Session["Kullanici"]).firmaID;
            return View(db.Referans.Where(x => x.firmaID == firmaID).ToList());
        }

        [HttpGet]
        public ActionResult Ekle()
        { 
            return View();
        }


        [HttpPost]
        public ActionResult Ekle(Referans r)
        {
            r.firmaID = ((Kullanici)Session["Kullanici"]).firmaID;
            FirmaContext db = new FirmaContext();
            db.Referans.Add(r);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            FirmaContext db = new FirmaContext();
            Referans r = db.Referans.Where(x => x.referansID == id).FirstOrDefault();
            if(r!=null)
            {
                db.Referans.Remove(r);
                db.SaveChanges();

            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Duzenle(int id)
        {
            TempData["referansID"] = id;
            FirmaContext db = new FirmaContext();
            Referans r = db.Referans.Where(x=> x.referansID == id).FirstOrDefault();
           
            return View(r);
        }

        [HttpPost]
        public ActionResult Duzenle(Referans r)
        {
            int referansID = TempData["referansID"] == null ? 0 : (int)TempData["referansID"];
            FirmaContext db = new FirmaContext();
            Referans referans = db.Referans.Where(x=>x.referansID == referansID).FirstOrDefault();
            if(referans != null)
            {
                referans.ad = r.ad;
                referans.resim = r.resim;
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}