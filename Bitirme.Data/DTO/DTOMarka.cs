using Bitirme.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitirme.Data.DTO
{
    public class DTOMarka
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Telefon { get; set; }
        public int AVMId { get; set; }
        public AVM AVM { get; set; }
        public List<Resim> Resim { get; set; }
    }
}
