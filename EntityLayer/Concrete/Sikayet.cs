using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Sikayet
    {
        public int Id { get; set; }
        public string SikayetBasligi { get; set; }
        public string SikayetIcerigi { get; set; }
        public int SikayetEdenKullanici { get; set; }
        public int SikayetEdilenIlanId { get; set; }
    }
}
