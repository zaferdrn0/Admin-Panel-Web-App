using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FirmaApp.Model;

namespace FirmaApp.Web.Controllers
{
    public class EpostaController : Controller
    {
        // GET: Eposta

        public ActionResult Index()
        {

            FirmaContext db = new FirmaContext();
            int firmaID = (int)((Kullanici)Session["Kullanici"]).firmaID;
            return View(db.Eposta.Where(x => x.firmaID == firmaID).ToList());

        }
        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }
        public ActionResult Sil(int id)
        {
            FirmaContext db = new FirmaContext();
            Eposta e = db.Eposta.Where(x => x.ePostaID == id).FirstOrDefault();
            if (e != null)
            {
                db.Eposta.Remove(e);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Ekle(Eposta e)
        {

            e.firmaID = ((Kullanici)Session["Kullanici"]).firmaID;
            FirmaContext db = new FirmaContext();
            db.Eposta.Add(e);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Duzenle(int id)
        {
            TempData["ePostaID"] = id;
            FirmaContext db = new FirmaContext();
            Eposta eposta = db.Eposta.Where(x => x.ePostaID == id).FirstOrDefault();
            return View(eposta);
        }

        [HttpPost]
        public ActionResult Duzenle(Eposta e)
        {
            int ePostaID = TempData["ePostaID"] == null ? 0 : (int)TempData["ePostaID"];
            //if (TempData["kullaniciID"] == null)
            //    kullaniciID = 0;
            //else
            //    kullaniciID = (int)TempData["kullaniciID"];

            FirmaContext db = new FirmaContext();
            Eposta eposta = db.Eposta.Where(x => x.ePostaID == ePostaID).FirstOrDefault();
            if (eposta != null)
            {
                eposta.posta = e.posta;

                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}