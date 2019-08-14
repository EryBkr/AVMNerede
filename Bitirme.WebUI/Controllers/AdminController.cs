using Bitirme.Data;
using Bitirme.Data.EFBusiness;
using Bitirme.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bitirme.WebUI.Controllers
{
    public class AdminController : Controller
    {
        IAdminRepository _admin;
        IAVMRepository _avm;
        IMarkaRepository _marka;
        ISehirRepository _sehir;

        public AdminController()
        {
            _admin = new EFAdminRepository();
            _avm = new EFAVMRepository();
            _marka = new EFMarkaRepository();
            _sehir = new EFSehirRepository();
        }


        //Giriş İşlemleri

        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(Admin admin)
        {
            var user = _admin.GetAdmin();
            if (user.UserName==admin.UserName&&user.Password==admin.Password)
            {
                Session["Admin"] = admin;
                return RedirectToAction("Index");
            }
            ViewBag.LogIn = "false";
            return View();
            
        }

        public ActionResult LogOut()
        {
            Session["Admin"] = null;
            return View("LogIn");
        }
        public ActionResult Index()
        {
            TempData["AVMSayisi"] = _avm.GetAVMs().Count();
            TempData["SehirSayisi"] = _sehir.GetSehirler().Count();
            TempData["MarkaSayisi"] = _marka.GetMarkas().Count();
            return View();
        }

        //Sehir İslemleri
        public ActionResult SehirIslem()
        {
            var sehirler = _sehir.GetSehirler();
            return View(sehirler);
        }

        [HttpGet]
        
        public ActionResult SehirEkle()
        {
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SehirEkle(Sehir sehir)
        {
            _sehir.PostSehir(sehir);
            ViewBag.Ekleme = "true";

            return View("SehirIslem", _sehir.GetSehirler());
        }

       
        public ActionResult SehirSil(int id)
        {
            _sehir.DeleteSehir(id);
            ViewBag.Silme = "true";
            return View("SehirIslem", _sehir.GetSehirler());
        }

        [HttpGet]
        public ActionResult SehirDuzenle(int id)
        {
            var sehir = _sehir.GetSehir(id);
            return View(sehir);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SehirDuzenle(Sehir sehir)
        {
            _sehir.UpdateSehir(sehir);
            ViewBag.Duzenleme = "true";
            return View("SehirIslem", _sehir.GetSehirler());
        }

        //AVM İşlemleri
        public ActionResult AVMIslem()
        {
            var avmler = _avm.GetAVMs();
            
            return View(avmler);
        }

        [HttpGet]
        public ActionResult AVMEkle()
        {
            TempData["Sehirler"] = _sehir.GetSehirler();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AVMEkle(AVM avm, List<HttpPostedFileBase> image)
        {
            Resim _resim;
            foreach (var item in image)
            {
                _resim = new Resim();
                var extension = Path.GetExtension(item.FileName);
                if (image != null && (extension == ".jpg" || extension == ".png" || extension == ".jpeg"))
                {
                    var path = Server.MapPath("~/UploadImages");
                    var RandomFileName = Path.GetRandomFileName();
                    var Name = Path.ChangeExtension(RandomFileName, ".jpg");
                    var final = Path.Combine(path, Name);
                    item.SaveAs(final);
                    _resim.Ad = Name;
                    avm.Resim.Add(_resim);

                }
            }
            _avm.PostAVM(avm);

            ViewBag.Ekleme = "true";
            return View("AVMIslem",_avm.GetAVMs());
        }
        public ActionResult AVMSil(int id)
        {
            _avm.DeleteAVM(id);
            ViewBag.Silme = "true";
            return View("AVMIslem",_avm.GetAVMs());
        }

        [HttpGet]
        public ActionResult AVMDuzenle(int id)
        {
            var avm = _avm.GetAVM(id);
            TempData["Sehirler"] = _sehir.GetSehirler();
            return View(avm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AVMDuzenle(AVM avm, List<HttpPostedFileBase> image)
        {
            Resim _resim;
            foreach (var item in image)
            {
                _resim = new Resim();
                var extension = Path.GetExtension(item.FileName);
                if (image != null && (extension == ".jpg" || extension == ".png" || extension == ".jpeg"))
                {
                    var path = Server.MapPath("~/UploadImages");
                    var RandomFileName = Path.GetRandomFileName();
                    var Name = Path.ChangeExtension(RandomFileName, ".jpg");
                    var final = Path.Combine(path, Name);
                    item.SaveAs(final);
                    _resim.Ad = Name;
                    avm.Resim.Add(_resim);

                }
            }
            _avm.UpdateAVM(avm);
            ViewBag.Duzenleme = "true";
            return View("AVMIslem", _avm.GetAVMs());
        }

        //Marka İşlemleri
        public ActionResult MarkaIslem()
        {
            var markalar = _marka.GetMarkas();
            return View(markalar);
        }

        [HttpGet]
        public ActionResult MarkaEkle()
        {
            TempData["AVMler"] = _avm.GetAVMs();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MarkaEkle(Marka marka,List<HttpPostedFileBase> image)
        {
            Resim _resim;
            foreach (var item in image)
            {
                _resim = new Resim();
                var extension = Path.GetExtension(item.FileName);
                if (image != null && (extension == ".jpg" || extension == ".png" || extension == ".jpeg"))
                {
                    var path = Server.MapPath("~/UploadImages");
                    var RandomFileName = Path.GetRandomFileName();
                    var Name = Path.ChangeExtension(RandomFileName, ".jpg");
                    var final = Path.Combine(path, Name);
                    item.SaveAs(final);
                    _resim.Ad = Name;
                    marka.Resim.Add(_resim);
                    
                }
            }
            
            _marka.PostMarka(marka);

            ViewBag.Ekleme = "true";
            return View("MarkaIslem", _marka.GetMarkas());
        }

        public ActionResult MarkaSil(int id)
        {
            _marka.DeleteMarka(id);
            ViewBag.Silme = "true";
            return View("MarkaIslem", _marka.GetMarkas());
        }

        [HttpGet]
        public ActionResult MarkaDuzenle(int id)
        {
            var marka = _marka.GetMarka(id);
            TempData["AVMler"] = _avm.GetAVMs();
            return View(marka);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MarkaDuzenle(Marka marka,List<HttpPostedFileBase> image)
        {
            Resim _resim;
            foreach (var item in image)
            {
                _resim = new Resim();
                var extension = Path.GetExtension(item.FileName);
                if (image != null && (extension == ".jpg" || extension == ".png" || extension == ".jpeg"))
                {
                    var path = Server.MapPath("~/UploadImages");
                    var RandomFileName = Path.GetRandomFileName();
                    var Name = Path.ChangeExtension(RandomFileName, ".jpg");
                    var final = Path.Combine(path, Name);
                    item.SaveAs(final);
                    _resim.Ad = Name;
                    marka.Resim.Add(_resim);

                }
            }
            _marka.UpdateMarka(marka);
            ViewBag.Duzenleme = "true";
            return View("MarkaIslem", _marka.GetMarkas());
        }

    }
}