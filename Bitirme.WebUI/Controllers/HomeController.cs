using Bitirme.Data;
using Bitirme.Data.EFBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bitirme.WebUI.Controllers
{
    public class HomeController : Controller
    {
        IAVMRepository _avm;
        IMarkaRepository _marka;
        public HomeController()
        {
            _avm = new EFAVMRepository();
            _marka = new EFMarkaRepository();
        }
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult DetailsAVM(int id)
        {
            var avm = _avm.GetAVM(id);
            var marka = _marka.GetMarkas().Where(i => i.AVMId == id).ToList();
            TempData["marka"] = marka;
            return View(avm);
        }
    }
}