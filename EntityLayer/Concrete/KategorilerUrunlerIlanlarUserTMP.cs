using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class KategorilerUrunlerIlanlarUserTMP
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public int IlanId { get; set; }
        public string IlanAd { get; set; }
        public string Aciklama { get; set; }
        public string Yil { get; set; }
        public int Fiyat { get; set; }
        public string IlanSehir { get; set; }
        public string IlanIlce { get; set; }
        public string AcikAdres { get; set; }
        public IFormFile FotoUrl1 { get; set; }
        public string FotoUrl2 { get; set; }
        public string FotoUrl3 { get; set; }
        public string FotoUrl4 { get; set; }
        public string FotoUrl5 { get; set; }
        public string KategriId { get; set; }
        public string KategoriAd { get; set; }
        public int UrunId { get; set; }
        public string UrunCesiti { get; set; }
    }
}
