using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bitirme.Entity;

namespace Bitirme.Data.EFBusiness
{
    public class EFAdminRepository : IAdminRepository
    {
        DataContext db = new DataContext();
        public Admin GetAdmin()
        {
            var admin = db.Admin.FirstOrDefault();
            return admin;
        }
    }
}
