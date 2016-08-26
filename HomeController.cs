using DialogExample.Models;
using DialogExample.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DialogExample.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            KullaniciViewModel model = new KullaniciViewModel();
            DialogEntities2 db = new DialogEntities2();

            List<Bolum> BolumList = db.Bolum.OrderBy(f => f.BolumAdi).ToList();

            model.BolumList = (from s in BolumList
                               select new SelectListItem
                               {
                                   Text = s.BolumAdi,
                                   Value = s.BolumID.ToString()
                               }).ToList();

            model.BolumList.Insert(0, new SelectListItem { Value = "", Text = "Seçiniz", Selected = true });

            return View(model);
        }
        [HttpPost]
       public JsonResult ProgramList(int id)
        {
            DialogEntities2 db = new DialogEntities2();
            List<Program> ProgramList = db.Program.Where(f => f.BolumID == id).OrderBy(f => f.ProgramAdi).ToList();

            List<SelectListItem> itemList = (from i in ProgramList
                                             select new SelectListItem
                                             {
                                                Value =i.ProgramID.ToString(),
                                                Text =i.ProgramAdi
                                             }).ToList();

            return Json(itemList, JsonRequestBehavior.AllowGet);
        }       

        public PartialViewResult KullaniciList()
        {
            DialogEntities2 db = new DialogEntities2();

            List<KullaniciViewModel> kullaniciList = (from k in db.Kullanicilar
                                                      select new KullaniciViewModel
                                                      {
                                                          
                                                          Tc = k.Tc,
                                                          AdSoyad = k.AdSoyad,
                                                          Bolumler = (int)k.Bolumler,
                                                          Programlar =(int) k.Programlar,
                                                          
                                                          Cep = k.Cep,
                                                          Bisiklet = k.Bisiklet,
                                                          Verilis = k.Verilis,
                                                          Iade = k.Iade,
                                                          KullaniciID = k.KullaniciID
                                                      }).OrderByDescending(f => f.KullaniciID).ToList();

            return PartialView(kullaniciList);
        }

        [HttpPost]
        public string Create(KullaniciViewModel model) 
        {
            try
            {
                DialogEntities2 db = new DialogEntities2();
                Kullanicilar kullanici = null;
                if (model.KullaniciID > 0)
                    kullanici = db.Kullanicilar.FirstOrDefault(f => f.KullaniciID == model.KullaniciID);
                else
                    kullanici = new Kullanicilar();

                kullanici.Tc = model.Tc;
                kullanici.AdSoyad = model.AdSoyad;
                kullanici.Bolumler = model.BolumID;  // bolumler
                kullanici.Programlar = model.ProgramID;
                kullanici.Cep = model.Cep;
                kullanici.Bisiklet = model.Bisiklet;
                kullanici.Verilis = model.Verilis.Date;
                kullanici.Iade = model.Iade.Date;
                if (model.KullaniciID == 0)
                    db.Kullanicilar.Add(kullanici);

                db.SaveChanges();
               
              

              return "1";
            }
            catch
            {
                return "-1";
            }
           
        }

        [HttpPost]
        public string Delete(int id)
        {
            try
            {
                DialogEntities2 db = new DialogEntities2();
                var kullanici = db.Kullanicilar.FirstOrDefault(t => t.KullaniciID == id);
                db.Kullanicilar.Remove(kullanici);
                db.SaveChanges();
                return "1";
            }
            catch
            {

                return "-1";
            }
        }

        [HttpPost]
        public JsonResult KullaniciGetir(int id) 
        {
            DialogEntities2 db = new DialogEntities2();
            Kullanicilar kullanici = db.Kullanicilar.FirstOrDefault(f => f.KullaniciID == id);
            KullaniciViewModel model = new KullaniciViewModel();
            model.Tc = kullanici.Tc;
            model.AdSoyad = kullanici.AdSoyad;
            model.Bolumler = (int)kullanici.Bolumler;
           model.Programlar = (int)kullanici.Programlar;
            model.Cep = kullanici.Cep;
            model.Bisiklet = kullanici.Bisiklet;
            model.Verilis = kullanici.Verilis;
            model.Iade = kullanici.Iade;
            model.KullaniciID = kullanici.KullaniciID;
            return Json(model, JsonRequestBehavior.AllowGet);
        }

    }
}
