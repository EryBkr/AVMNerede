using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitirme.Entity
{
    public class AVM
    {
        public AVM()
        {
            Resim = new List<Resim>();
        }
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Telefon { get; set; }
        public string Adres { get; set; }
        public double cordX { get; set; }
        public double cordY { get; set; }
        public int SehirId { get; set; }
        public Sehir Sehir { get; set; }
        public List<Marka> Marka { get; set; }
        public List<Resim> Resim { get; set; }
    }
}
