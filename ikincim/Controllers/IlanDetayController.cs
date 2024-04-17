using AutoMapper;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using ikincim.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ikincim.Controllers
{
    public class IlanDetayController : Controller
    {
        private readonly UserManager<AppUser> userManager;

        public IlanDetayController(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }
        UrunlerManager urunlerManager = new UrunlerManager(new EfUrunlerDal());
        IlanlarManager ilanlarManager = new IlanlarManager(new EfIlanlarDal());
        KategorilerManager kategorilerManager = new KategorilerManager(new EfKategorilerDal());
        BegeniManager begeniManager = new BegeniManager(new EfBegeniDal());
        SikayetManager sikayetManager = new SikayetManager(new EfSikayetDal());
        KategorilerIlanlarUrunlerUser kategorilerUrunlerIlanlarUser = new KategorilerIlanlarUrunlerUser();

        public async Task<IActionResult> Index(int id)
        {
            kategorilerUrunlerIlanlarUser.kategorilers = kategorilerManager.TGetAll();
            kategorilerUrunlerIlanlarUser.kategorilers2 = kategorilerManager.TGetAll();
            kategorilerUrunlerIlanlarUser.urunlers2 = urunlerManager.TGetAll();
            int kategoriId = ilanlarManager.TGetById(id).KategorilerId;
            kategorilerUrunlerIlanlarUser.urunlers = urunlerManager.TGetAll().Where(x => x.KategorilerId == kategoriId).ToList();
            kategorilerUrunlerIlanlarUser.ılanlars = ilanlarManager.TGetAll().Where(x => x.Id == id).ToList();
            kategorilerUrunlerIlanlarUser.userVeIlanlarTMPs = (from p in ilanlarManager.TGetAll().Where(x => x.Id == id).ToList()
                                                               join e in userManager.Users.ToList()
                                                                    on p.IlanSahibiId equals e.Id
                                                               select new UserVeIlanlarTMP
                                                               {
                                                                   Aciklama = p.Aciklama,
                                                                   Ad = e.Ad,
                                                                   Soyad = e.Soyad,
                                                                   PhoneNumber = e.PhoneNumber,
                                                                   FotoUrl1 = p.FotoUrl1,
                                                                   FotoUrl2 = p.FotoUrl2,
                                                                   FotoUrl3 = p.FotoUrl3,
                                                                   FotoUrl4 = p.FotoUrl4,
                                                                   FotoUrl5 = p.FotoUrl5,
                                                                   Fiyat= p.Fiyat,
                                                                   IlanAd= p.IlanAd,
                                                                   Yil = p.Yil,
                                                                   IlanSehir = p.IlanSehir,
                                                                   IlanIlce = p.IlanIlce,
                                                                   AcikAdres = p.AcikAdres,
                                                                   IlanId =  p.Id
                                                               });
            if(User.Identity.IsAuthenticated)
            {
                var currentUser = await userManager.FindByNameAsync(User.Identity!.Name!);

                bool zatenBegendinMi = false;
                var begeniler = begeniManager.TGetAll();
                string begenmis = "Beğeniyi Kaldır";
                string begenmemis = "Beğen";
                TempData["Durum"] = null;
                foreach (var item in begeniler)
                {
                    if (item.IlanId == id && item.BegenenKullaniciId == currentUser.Id)
                    {
                        zatenBegendinMi = true;
                    }
                }
                if (zatenBegendinMi)
                {
                    TempData["Durum"] = begenmis;
                }
            }    
            return View(kategorilerUrunlerIlanlarUser);
        }

        public async Task<IActionResult> Begeni(int id)
        {
            var currentUser = await userManager.FindByNameAsync(User.Identity!.Name!);
            var begeni = new Begeni()
            {
                IlanId = id,
                BegenenKullaniciId = currentUser.Id
            };
            begeniManager.TAdd(begeni);
            int ilanId = ilanlarManager.TGetById(id).Id;
            return RedirectToAction("Index", "IlanDetay",new {id = ilanId});   // gideceğimiz sayfaya parametre de yolladık
        }
        public async Task<IActionResult> BegeniKaldir(int id)
        {
            var begeniler = begeniManager.TGetAll();
            var currentUser = await userManager.FindByNameAsync(User.Identity!.Name!);

            foreach (var item in begeniler)
            {
                if (item.IlanId == id && item.BegenenKullaniciId == currentUser.Id)
                {
                    begeniManager.TDelete(item);
                }
            }
            int ilanId = ilanlarManager.TGetById(id).Id;
            return RedirectToAction("Index", "IlanDetay", new { id = ilanId });   // gideceğimiz sayfaya parametre de yolladık bunu unutma
        }

        public IActionResult SikayetEt(int id)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SikayetEt(SikayetViewModel sikayetViewModel,int id)
        {
            var currentUser = await userManager.FindByNameAsync(User.Identity!.Name!);
            Sikayet sikayet = new Sikayet()
            {
                SikayetEdilenIlanId = id,
                SikayetBasligi = sikayetViewModel.SikayetBasligi,
                SikayetIcerigi = sikayetViewModel.SikayetIcerigi,
                SikayetEdenKullanici = currentUser.Id
            };
            TempData["Sikayet"] = null;
            if (sikayet.SikayetEdilenIlanId != null && sikayet.SikayetEdenKullanici != null && sikayet.SikayetBasligi != null && sikayet.SikayetIcerigi != null) 
            {
                sikayetManager.TAdd(sikayet);   
                TempData["Sikayet"] = "Sikayet Gönderildi";
            }
            else
            {
                TempData["Sikayet"] = "Sikayet Gönderilemedi. Boş yer bırakmayınız";
                return View();
            }

            return View();
        }

    }
}
