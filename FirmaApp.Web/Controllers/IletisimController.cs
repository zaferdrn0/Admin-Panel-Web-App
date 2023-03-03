using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FirmaApp.Model;

namespace FirmaApp.Web.Controllers
{
    public class IletisimController : Controller
    {
        // GET: Iletisim

        public ActionResult Index()
        {
            FirmaContext db = new FirmaContext();
            int firmaID = (int)((Kullanici)Session["Kullanici"]).firmaID;
            return View(db.Mesaj.Where(x => x.firmaID == firmaID).ToList());
        }

        [HttpGet]
        public ActionResult Gonder()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Gonder(Mesaj m)
        {
            m.firmaID = ((Kullanici)Session["Kullanici"]).firmaID;
            FirmaContext db = new FirmaContext();
            db.Mesaj.Add(m);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            FirmaContext db = new FirmaContext();
            Mesaj m = db.Mesaj.Where(x => x.mesajID == id).FirstOrDefault();
            if (m != null)
            {
                db.Mesaj.Remove(m);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }



    }
}