using System.ComponentModel.DataAnnotations;

namespace ikincim.Models
{
    public class SikayetViewModel
    {
        [Display(Name = "SikayetBasligi")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string SikayetBasligi { get; set; }

        [Display(Name = "SikayetIcerigi")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string SikayetIcerigi { get; set; }
        public int SikayetEdenKullanici { get; set; }
        public int SikayetEdilenIlanId { get; set; }
    }
}
