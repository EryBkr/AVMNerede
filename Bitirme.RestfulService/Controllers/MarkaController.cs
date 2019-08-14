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
    public class MarkaController : ApiController
    {
        IMarkaRepository markaRep;

        public MarkaController()
        {
            markaRep = new EFMarkaRepository();
        }

        [HttpDelete]
        public IHttpActionResult DeleteMarka(int id)
        {
            markaRep.DeleteMarka(id);
            return Ok("Silme İşlemi Başarılı");
        }

        [HttpGet]
        public IHttpActionResult GetMarkalar()
        {
            var markalar = markaRep.GetMarkas();
            return Ok(markalar);
        }

        [HttpGet]
        public IHttpActionResult GetMarka(int id)
        {
            var marka = markaRep.GetMarka(id);
            return Ok(marka);
        }

        [HttpPost]
        public IHttpActionResult PostMarka(Marka marka)
        {
            markaRep.PostMarka(marka);
            return Ok("Kaydetme İşlemi Başarılı");
        }

        [HttpPut]
        public IHttpActionResult PutMarka(Marka marka)
        {
            markaRep.UpdateMarka(marka);
            return Ok("Değiştirme İşlemi Başarılı");
        }
    }
}
