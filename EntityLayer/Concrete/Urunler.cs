using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Urunler
    {
        public int Id { get; set; }
        public string UrunCesiti { get; set; }
        public int KategorilerId { get; set; }
       
    }
}
