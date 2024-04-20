using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class KategorilerIlanlarUrunlerUser
    {
        public IEnumerable<AppUser> users { get; set; }
        public IEnumerable<Kategoriler> kategorilers { get; set; }
        public IEnumerable<Kategoriler> kategorilers2 { get; set; }
        public IEnumerable<Ilanlar> ılanlars { get; set; }
        public IEnumerable<Urunler> urunlers { get; set; }
        public IEnumerable<Urunler> urunlers2 { get; set; }
        public IEnumerable<UserVeIlanlarTMP> userVeIlanlarTMPs { get; set; }
        public IEnumerable<KategorilerUrunlerTMP> kategorilerUrunlerTMPs { get; set; }
        public IEnumerable<KategorilerUrunlerIlanlarUserTMP> kategorilerUrunlerIlanlarUserTMPs { get; set; }
        public IEnumerable<ProfilimTMP> profilimTMPs { get;set; }
        public IEnumerable<Begeni> begenis { get;set; }
        public IEnumerable<BegendigimIlanlarTMP> begendigimTMPs { get; set; }

        [Display(Name = "UserId")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string UserId { get; set; }

        [Display(Name = "UserName")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string UserName { get; set; }

        [Display(Name = "IlanId")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public int IlanId { get; set; }

        [Display(Name = "IlanAd")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string IlanAd { get; set; }

        [Display(Name = "Aciklama")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string Aciklama { get; set; }

        [Display(Name = "Yil")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string Yil { get; set; }

        [Display(Name = "Fiyat")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public int Fiyat { get; set; }

        [Display(Name = "IlanSehir")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string IlanSehir { get; set; }

        [Display(Name = "IlanIlce")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string IlanIlce { get; set; }

        [Display(Name = "AcikAdres")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string AcikAdres { get; set; }

        [Display(Name = "FotoUrl1")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string FotoUrl1 { get; set; }

        [Display(Name = "FotoUrl2")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string FotoUrl2 { get; set; }

        [Display(Name = "FotoUrl3")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string FotoUrl3 { get; set; }

        [Display(Name = "FotoUrl4")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string FotoUrl4 { get; set; }

        [Display(Name = "FotoUrl5")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string FotoUrl5 { get; set; }

        [Display(Name = "KategriId")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public int KategriId { get; set; }

        [Display(Name = "KategoriAd")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string KategoriAd { get; set; }

        [Display(Name = "UrunId")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public int UrunId { get; set; }

        [Display(Name = "UrunCesiti")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string UrunCesiti { get; set; }

    }
}
