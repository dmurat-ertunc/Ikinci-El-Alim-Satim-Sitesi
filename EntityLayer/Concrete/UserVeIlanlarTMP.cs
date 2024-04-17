using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class UserVeIlanlarTMP
    {
        public int UserId { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string PhoneNumber { get; set; }
        public int IlanId { get; set; }
        public int UrunlerId { get; set; }
        public int KategorilerId { get; set; }
        public int IlanSahibiId { get; set; }
        public string IlanAd { get; set; }
        public string Aciklama { get; set; }
        public string Yil { get; set; }
        public int Fiyat { get; set; }
        public string IlanSehir { get; set; }
        public string IlanIlce { get; set; }
        public string AcikAdres { get; set; }
        public int AktifSatildi { get; set; }
        public string FotoUrl1 { get; set; }
        public string FotoUrl2 { get; set; }
        public string FotoUrl3 { get; set; }
        public string FotoUrl4 { get; set; }
        public string FotoUrl5 { get; set; }
    }
}
