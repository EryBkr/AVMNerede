using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitirme.Entity
{
    public class Resim
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public List<AVM> AVM { get; set; }
        public List<Marka> Marka { get; set; }
        
    }
}
