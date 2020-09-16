using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using BaseDemo.Models;
using BaseDemo.Models.Entity;
namespace BaseDemo.Controllers
{
    public class KullaniciController : Controller
    {
        KullaniciViewModel model = new KullaniciViewModel();
        UsersEntities db = new UsersEntities();
        // GET: Kullanici

        public ActionResult Index()
        {
            KullaniciViewModel model = new KullaniciViewModel();
            model.Kullanicis = db.Kullanici.ToList();

            return View(model);


        }

        public ActionResult Kullanici(int id)
        {

            KullaniciViewModel model = new KullaniciViewModel();
            model.Illers = db.Iller.ToList();
            model.KullaniciTips = db.KullaniciTip.ToList();

            if (id == 0)
            {
                model.Kullanici = new Kullanici();
            }
            else
            {
                model.Kullanici = db.Kullanici.Find(id);
            }
            return View(model);
        }

        
        public ActionResult KullaniciKaydet(KullaniciViewModel model)
        {
            if (model.Kullanici.Id == 0)
            {
                db.Kullanici.Add(model.Kullanici);
                db.SaveChanges();

                return RedirectToAction("Index", "Kullanici");
            }
            else
            {
                db.Entry(model.Kullanici).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Index", "Kullanici");

        }

        public ActionResult Sil(int id)
        {
            var user = db.Kullanici.Find(id);
            db.Kullanici.Remove(user);
            db.SaveChanges();

            return RedirectToAction("Index", "Kullanici");
        }


        #region Eski Controller 
        //[HttpPost]
        //public ActionResult Save(KullaniciViewModel model)
        //{

        //    db.Kullanici.Add(model.Kullanici);
        //    db.SaveChanges();

        //    return RedirectToAction("Index", "Kullanici");
        //}


        //public ActionResult Guncelle(Kullanici model)
        //{
        //    var user = db.Kullanici.Find(model.Id);
        //    user.Ad = model.Ad;
        //    user.Soyad = model.Soyad;
        //    user.Email = model.Email;
        //    user.Telefon = model.Telefon;
        //    user.TipId = model.TipId;
        //    user.Aktif = model.Aktif;
        //    db.SaveChanges();

        //    return RedirectToAction("Index", "Kullanici");
        //}
        #endregion

    }
}