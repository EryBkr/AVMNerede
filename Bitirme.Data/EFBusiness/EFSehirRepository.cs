using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bitirme.Data.DTO;
using Bitirme.Entity;

namespace Bitirme.Data.EFBusiness
{
    public class EFSehirRepository : ISehirRepository
    {
        DataContext db = new DataContext();
        public void DeleteSehir(int id)
        {
            db.Sehir.Remove(db.Sehir.Find(id));
            db.SaveChanges();
        }

        public DTOSehir GetSehir(int id)
        {
            var sehir = db.Sehir.Where(i => i.Id == id).Select(i => new DTOSehir { Id=i.Id,Ad = i.Ad, AVM = i.AVM, AVMCount = i.AVM.Count }).FirstOrDefault();
            return sehir;
        }

        public List<DTOSehir> GetSehirler()
        {
            var sehir = db.Sehir.Select(i =>new DTOSehir {Id=i.Id, Ad = i.Ad, AVM = i.AVM,AVMCount=i.AVM.Count}).ToList();
            return sehir;
        }

        public void PostSehir(Sehir sehir)
        {
            db.Sehir.Add(sehir);
            db.SaveChanges();
        }

        public void UpdateSehir(Sehir sehir)
        {
            db.Sehir.Find(sehir.Id).Ad = sehir.Ad;
            db.SaveChanges();
        }
    }
}
