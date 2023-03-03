using FirmaApp.Model;
using FirmaApp.Web.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirmaApp.Web.Controllers
{
    public class KullaniciController : Controller
    {
        // GET: Kullanici
        public ActionResult Index()
        {
            FirmaContext db  = new FirmaContext();
            int firmaID = (int)((Kullanici)Session["Kullanici"]).firmaID;
            return View(db.Kullanici.Where(x => x.firmaID == firmaID).ToList());
        }
        public ActionResult Sil(int id)
        {
            FirmaContext db = new FirmaContext();
            Kullanici k = db.Kullanici.Where(x=> x.kullaniciID == id).FirstOrDefault();
            if(k!= null)
            {
                db.Kullanici.Remove(k);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(Kullanici k,HttpPostedFileBase foto)
        {
            ImageManager resim = new ImageManager();
            var sonuc = resim.Ekle(foto);
         
            if (sonuc.basariliMi == false)
            {
                ViewBag.sonuc = sonuc.mesaj;
                return View(); // kanki yerinde oslam şunu yapardım, kendin yolla ajax isteeğini. kaydet butonu var ya, onun ajaxını kendin yaz. biraz zor olur ama ben öyle yapardım.
                // başka türlü, daha kolay şunu yapabilirsin, yine redirectoaction de, bi hata sayfasına yönlendir, hata mesajını orda göster. ama pek güzel olmaz böyle
                // en iyisi, kaydet butonu için kendin ajax isteği yapıp öyle gönder verileri. ben böyle yapardım tamamdır zeki çok saol allah razi olsun bisi diil, ben kaçiyom taam by
            }
            k.resim = sonuc.ad;


            k.firmaID = ((Kullanici)Session["Kullanici"]).firmaID;
            FirmaContext db = new FirmaContext();
            db.Kullanici.Add(k);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Duzenle(int id)
        {
            TempData["kullaniciID"] = id;
            FirmaContext db = new FirmaContext();
            Kullanici kullanici = db.Kullanici.Where(x => x.kullaniciID == id).FirstOrDefault();
            return View(kullanici);
        }

        [HttpPost]
        public ActionResult Duzenle(Kullanici k)
        {
            int kullaniciID = TempData["kullaniciID"] == null ? 0 : (int)TempData["kullaniciID"];
            //if (TempData["kullaniciID"] == null)
            //    kullaniciID = 0;
            //else
            //    kullaniciID = (int)TempData["kullaniciID"];

            FirmaContext db = new FirmaContext();
            Kullanici kullanici = db.Kullanici.Where(x => x.kullaniciID == kullaniciID).FirstOrDefault();
            if(kullanici != null)
            {
                kullanici.ad = k.ad;
                kullanici.soyad = k.soyad;
                kullanici.ePosta = k.ePosta;
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}