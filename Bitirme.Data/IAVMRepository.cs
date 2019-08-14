using Bitirme.Data.DTO;
using Bitirme.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitirme.Data
{
    public interface IAVMRepository
    {
        List<DTOAVM> GetAVMs();
        void PostAVM(AVM avm);
        void DeleteAVM(int id);
        void UpdateAVM(AVM avm);
        DTOAVM GetAVM(int id);


    }
}
