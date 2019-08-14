using Bitirme.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitirme.Data.DTO
{
    public class DTOSehir
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public int AVMCount { get; set; }
        public List<AVM> AVM { get; set; }
    }
}
