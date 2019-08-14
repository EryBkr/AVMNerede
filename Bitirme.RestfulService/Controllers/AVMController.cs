using Bitirme.Data;
using Bitirme.Data.EFBusiness;
using Bitirme.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Bitirme.RestfulService.Controllers
{
    public class AVMController : ApiController
    {
        IAVMRepository avmRep;
        public AVMController()
        {
            avmRep = new EFAVMRepository();
        }

        [HttpGet]
        public IHttpActionResult GetAVMs()
        {
            var avmler = avmRep.GetAVMs();

            return Ok(avmler);
        }

        [HttpGet]
        public IHttpActionResult GetAVM(int id)
        {
            var avm = avmRep.GetAVM(id);
            return Ok(avm);
        }

        [HttpDelete]
        public IHttpActionResult DeleteAVM(int id)
        {
            avmRep.DeleteAVM(id);
            return Ok("Silme İşlemi Başarılı");
        }

        [HttpPost]
        public IHttpActionResult PostAVM(AVM avm)
        {
            avmRep.PostAVM(avm);
            return Ok("Ekleme İşlemi Başarılı");
        }

        [HttpPut]
        public IHttpActionResult PutAVM(AVM avm)
        {
            avmRep.UpdateAVM(avm);
            return Ok("Değiştirme İşlemi Başarılı");
        }

    }
}
