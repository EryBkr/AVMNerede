using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Bitirme.Entity;

namespace Bitirme.Data.EFBusiness
{
    class DataInitilaizer:DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            List<Sehir> sehir = new List<Sehir>()
            {
                new Sehir(){Ad="İstanbul"},
                new Sehir(){Ad="İzmir"},
                new Sehir(){Ad="Ankara"},
                new Sehir(){Ad="Sakarya"}
            };
            foreach (var item in sehir)
            {
                context.Sehir.Add(item);
            }
            context.SaveChanges();
            Admin admin = new Admin() {UserName="info@admin.com",Password="Admin123"};
            context.Admin.Add(admin);
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
