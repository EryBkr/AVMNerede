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
    public class SehirController : ApiController
    {
        ISehirRepository sehirRep;
        public SehirController()
        {
            sehirRep = new EFSehirRepository();
        }

        [HttpDelete]
        public IHttpActionResult DeleteSehirler(int id)
        {
            sehirRep.DeleteSehir(id);
            return Ok("Sehir Silindi");
        }

        [HttpGet]
        public IHttpActionResult GetSehirler()
        {
            var sehirler = sehirRep.GetSehirler();
            return Ok(sehirler);
        }

        [HttpGet]
        public IHttpActionResult GetSehir(int id)
        {
            var sehir = sehirRep.GetSehir(id);
            return Ok(sehir);
        }

        [HttpPost]
        public IHttpActionResult AddSehir(Sehir sehir)
        {
            sehirRep.PostSehir(sehir);
            return Ok("Kaydetme İşlemi Başarılı");
        }

        [HttpPut]
        public IHttpActionResult UpSehir(Sehir sehir)
        {

            sehirRep.UpdateSehir(sehir);
            return Ok("Düzeltme İşlemi Başarılı");

        }
    }
}
