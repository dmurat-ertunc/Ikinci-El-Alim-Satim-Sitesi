using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class BegendigimIlanlarTMP
    {
        public int Id { get; set; }
        public int UrunlerId { get; set; }
        public string UrunCesiti { get; set; }
        public int KategorilerId { get; set; }
        public string KategroiAd { get; set; }
        public int IlanSahibiId { get; set; }
        public string IlanAd { get; set; }
        public string Aciklama { get; set; }
        public int Fiyat { get; set; }
        public string FotoUrl2 { get; set; }
    }
}
