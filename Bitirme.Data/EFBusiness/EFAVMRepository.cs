using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bitirme.Data.DTO;
using Bitirme.Entity;

namespace Bitirme.Data.EFBusiness
{
    public class EFAVMRepository : IAVMRepository
    {
        DataContext db = new DataContext();
        public void DeleteAVM(int id)
        {
            db.AVM.Remove(db.AVM.Find(id));
            db.SaveChanges();
        }

        public DTOAVM GetAVM(int id)
        {
            var avm = db.AVM.Where(i => i.Id == id)
                .Select(i => 
                new DTOAVM { Ad = i.Ad,Adres=i.Adres,cordX=i.cordX,cordY=i.cordY,Marka=i.Marka,Sehir=i.Sehir,SehirId=i.SehirId,Telefon=i.Telefon,Id=i.Id, MarkaCount = i.Marka.Count,Resim=i.Resim}).FirstOrDefault();
            return avm;
        }

        public List<DTOAVM> GetAVMs()
        {
            var avmler = db.AVM
                .Select(i => 
                new DTOAVM { Ad = i.Ad, Adres = i.Adres, cordX = i.cordX, cordY = i.cordY, Marka = i.Marka, Sehir = i.Sehir, SehirId = i.SehirId, Telefon = i.Telefon, Id = i.Id, MarkaCount = i.Marka.Count, Resim = i.Resim }).ToList();
            return avmler;
        }

        public void PostAVM(AVM avm)
        {
            db.AVM.Add(avm);
            db.SaveChanges();
        }

        public void UpdateAVM(AVM avm)
        {
            foreach (var item in db.Resim.Where(i=>i.AVM.Any(r=>r.Id==avm.Id)).ToList())
            {
                db.Resim.Remove(item);
            }
            
            db.AVM.Find(avm.Id).Ad = avm.Ad;
            db.AVM.Find(avm.Id).Adres = avm.Adres;
            db.AVM.Find(avm.Id).cordX = avm.cordX;
            db.AVM.Find(avm.Id).cordY = avm.cordY;
            db.AVM.Find(avm.Id).Telefon = avm.Telefon;
            db.AVM.Find(avm.Id).SehirId = avm.SehirId;
            db.AVM.Find(avm.Id).Resim = avm.Resim;
            db.SaveChanges();
        }
    }
}
