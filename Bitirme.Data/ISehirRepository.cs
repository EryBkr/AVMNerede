using Bitirme.Data.DTO;
using Bitirme.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitirme.Data
{
    public interface ISehirRepository
    {
        List<DTOSehir> GetSehirler();
        void PostSehir(Sehir avm);
        void DeleteSehir(int id);
        void UpdateSehir(Sehir avm);
        DTOSehir GetSehir(int id);
    }
}
