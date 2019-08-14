using Bitirme.Data.DTO;
using Bitirme.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitirme.Data
{
    public interface IMarkaRepository
    {
        List<DTOMarka> GetMarkas();
        void PostMarka(Marka avm);
        void DeleteMarka(int id);
        void UpdateMarka(Marka avm);
        DTOMarka GetMarka(int id);
    }
}
