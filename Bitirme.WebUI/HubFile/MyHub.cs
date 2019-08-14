using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bitirme.Data;
using Bitirme.Data.EFBusiness;
using Microsoft.AspNet.SignalR;

namespace Bitirme.WebUI.HubFile
{
    public class MyHub : Hub
    {
        IAVMRepository _avm = new EFAVMRepository();
        public void getCollectionPlaceMark()
        {
            var allPlace = _avm.GetAVMs();
            Clients.Caller.allPlaceMark(allPlace);
        }
        public void araBul(string name)
        {
            var bulunanAVM = _avm.GetAVMs().Where(i => i.Sehir.Ad.Contains(name) || i.Marka.Any(r => r.Ad.Contains(name)) || i.Ad.Contains(name)).ToList();
            Clients.Caller.bulunanAvmler(bulunanAVM);
        }
    }
}