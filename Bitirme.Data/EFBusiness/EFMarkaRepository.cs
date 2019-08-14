using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bitirme.Data.DTO;
using Bitirme.Entity;

namespace Bitirme.Data.EFBusiness
{
    public class EFMarkaRepository : IMarkaRepository
    {
        DataContext db = new DataContext();
        public void DeleteMarka(int id)
        {
            db.Marka.Remove(db.Marka.Find(id));
            db.SaveChanges();
        }

        public DTOMarka GetMarka(int id)
        {
            var marka = db.Marka.Where(i => i.Id == id).Select(i => new DTOMarka { Ad = i.Ad, Id = i.Id, AVMId = i.AVM.Id, Telefon = i.Telefon, AVM = i.AVM,Resim=i.Resim }).FirstOrDefault();
            return marka;
        }

        public List<DTOMarka> GetMarkas()
        {
            var markalar = db.Marka.Select(i => new DTOMarka { Ad = i.Ad, Id = i.Id, AVMId = i.AVM.Id, Telefon = i.Telefon,AVM=i.AVM,Resim=i.Resim}).ToList();
            return markalar;
        }

        public void PostMarka(Marka marka)
        {
            db.Marka.Add(marka);
            db.SaveChanges();
        }

        public void UpdateMarka(Marka marka)
        {
            foreach (var item in db.Resim.Where(i => i.Marka.Any(r => r.Id == marka.Id)).ToList())
            {
                db.Resim.Remove(item);
            }
            
            db.Marka.Find(marka.Id).Ad = marka.Ad;
            db.Marka.Find(marka.Id).Telefon = marka.Telefon;
            db.Marka.Find(marka.Id).AVMId = marka.AVMId;
            db.Marka.Find(marka.Id).Resim = marka.Resim;
            db.SaveChanges();
        }
    }
}
