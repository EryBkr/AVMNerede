using Bitirme.Data.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bitirme.Entity;

namespace Bitirme.Data.EFBusiness
{
    public class DataContext:DbContext
    {
        public DataContext():base("BitirmeCon")
        {
            Database.SetInitializer(new DataInitilaizer());
        }

        public DbSet<AVM> AVM { get; set; }
        public DbSet<Marka> Marka { get; set; }
        public DbSet<Sehir> Sehir { get; set; }
        public DbSet<Admin> Admin{ get; set; }
        public DbSet<Resim> Resim { get; set; }
    }
}
