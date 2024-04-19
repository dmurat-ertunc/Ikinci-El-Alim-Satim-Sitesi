using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using ikincim.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ikincim.Controllers
{
    public class ProfilimController : Controller
    {
        KategorilerManager kategorilerManager = new KategorilerManager(new EfKategorilerDal());
        IlanlarManager ılanlarManager = new IlanlarManager(new EfIlanlarDal());
        UrunlerManager urunlerManager = new UrunlerManager(new EfUrunlerDal());
        BegeniManager begeniManager = new BegeniManager(new EfBegeniDal());
        KategorilerIlanlarUrunlerUser kategorilerIlanlarUrunlerUser = new KategorilerIlanlarUrunlerUser();

        private readonly UserManager<AppUser> userManager;

        public ProfilimController(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Ilanlarim()
        {
            var currentUser = await userManager.FindByNameAsync(User.Identity!.Name!);   // anlık olarak aktif olan kullanıcının verilerini tutmak

            //var begeniler = begeniManager.TGetAll().ToList();

            //foreach (var item in begeniler)
            //{
            //    var begeniSayisi = begeniManager.TGetAll().Where(x => x.Id == item.IlanId).Count();

            //}

            kategorilerIlanlarUrunlerUser.profilimTMPs = (from p in ılanlarManager.TGetAll().Where(x => x.IlanSahibiId == currentUser.Id).ToList()
                       join e in kategorilerManager.TGetAll().ToList()
                         on p.KategorilerId equals e.Id
                       join k in urunlerManager.TGetAll().ToList()
                         on p.UrunlerId equals k.Id
                       select new ProfilimTMP
                       {
                           IlanId = p.Id,
                           IlanAd = p.IlanAd,
                           Aciklama = p.Aciklama,
                           Fiyat = p.Fiyat,
                           KategoriAd = e.KategoriAd,
                           UrunCesiti = k.UrunCesiti,
                           FotoUrl2 = p.FotoUrl2                           
                       });

            bool satildiMı = false;
            var satilanlar = ılanlarManager.TGetAll();

            foreach( var item in satilanlar )
            {
                TempData[$"Durum{item.Id}"] = null;
                if(item.AktifSatildi ==1)
                {
                    satildiMı=true;
                }
                if(satildiMı)
                {
                    TempData[$"Durum{item.Id}"] = "SATILDI";
                    satildiMı=false;
                }
            }

            return View(kategorilerIlanlarUrunlerUser);                      

        }
        public async Task<IActionResult> SatildiIsaretle(int id)
        {
            var ilan = ılanlarManager.TGetById(id);
            ilan.AktifSatildi = 1;
            ılanlarManager.TUpdate(ilan);


             return RedirectToAction("Ilanlarim","Profilim" );
        }
        public async Task<IActionResult> Bilgilerim() {
            var currentUser = await userManager.FindByNameAsync(User.Identity!.Name!);

            var userInformationViewModel = new UserInformationViewModel()
            {
                Id = currentUser.Id,
                Name = currentUser.Ad,
                Surname = currentUser.Soyad,
                Email = currentUser.Email,
                UserName = currentUser.UserName,
                Yas = currentUser.Yas,
                PhoneNumber = currentUser.PhoneNumber
            };
            return View(userInformationViewModel);
        }
    }
}
