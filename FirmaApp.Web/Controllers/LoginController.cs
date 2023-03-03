using FirmaApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirmaApp.Web.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet] // sayfayı görmek istiyorum
        public ActionResult Index()
        {
          return View();
        }

        [HttpPost] // sayfadan veri gönderince 
        public ActionResult Index(string eposta,string sifre)
        {
            string uyari = "";
            FirmaContext db = new FirmaContext();
            Kullanici kul = db.Kullanici.Where(a => a.ePosta == eposta && a.sifre == sifre).FirstOrDefault();
            if (kul != null)
            {
                if(kul.aktifMi == true)
                {
                    Session["Kullanici"] = kul;
                    return RedirectToAction("Index", "Home");
                } 
                else
                    uyari = "Hay Aksi";
            }
            else
                uyari = "Kullanıcı adı veya şifre hatalı";
            ViewBag.bilgi = uyari;
            return View();
        }

        [HttpGet] // sayfayı görmek istiyorum
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}