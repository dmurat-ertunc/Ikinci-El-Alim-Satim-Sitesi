using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class KategorilerUrunlerIlanlar
    {
        public IEnumerable<Kategoriler> kategorilers { get; set; }
        public IEnumerable<Kategoriler> kategorilers2 { get; set; }
        public IEnumerable<Kategoriler> kategorilers3 { get; set; }
        public IEnumerable<Ilanlar> ilanlars { get; set; }
        public IEnumerable<Urunler> urunlers { get; set; }
        public IEnumerable<Urunler> urunlers2 { get; set; }
    }
}
