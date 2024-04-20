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


        [HttpGet]
        public IActionResult PasswordChange()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> PasswordChange(UserPasswordChangeUserViewModel userPasswordChangeUserViewModel)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            var currenUser = await userManager.FindByNameAsync(User.Identity!.Name!);

            var checkOldPass = await userManager.CheckPasswordAsync(currenUser, userPasswordChangeUserViewModel.OldPassword);
            if(!checkOldPass) 
            {
                TempData["PassError"] = "Eski Şifreniz Yanlış";
                return View();
            }
            if(userPasswordChangeUserViewModel.OldPassword == userPasswordChangeUserViewModel.NewPassword) 
            {
                TempData["PassError"] = "Eski Şifre Yeni Şifre ile aynı olamaz";
                return View();
            }
            var resultChangePassword = await userManager.ChangePasswordAsync(currenUser,userPasswordChangeUserViewModel.OldPassword, userPasswordChangeUserViewModel.NewPassword);
            TempData["PassOkey"] = "Şifre Değiştirildi";


            return View();
        }

        [HttpGet]
        public async Task<IActionResult> EditUser() {
            var currenUser = await userManager.FindByNameAsync(User.Identity!.Name!);

            var userEditViewModel = new EditUserViewModel()
            {
                Name = currenUser.Ad,
                Surname = currenUser.Soyad,
                Email = currenUser.Email,
                UserName = currenUser.UserName,
                Yas = currenUser.Yas,
                PhoneNumber = currenUser.PhoneNumber
            };
            return View(userEditViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(EditUserViewModel editUserViewModel)
        {
            var currentUser = await userManager.FindByNameAsync(User.Identity!.Name!);

            if (currentUser != null)
            {
                currentUser.Ad = editUserViewModel.Name;
                currentUser.Soyad = editUserViewModel.Surname;
                currentUser.Email = editUserViewModel.Email;
                currentUser.UserName = editUserViewModel.UserName;
                currentUser.Yas = editUserViewModel.Yas;
                currentUser.PhoneNumber = editUserViewModel.PhoneNumber;
            }

            var updateUser = await userManager.UpdateAsync(currentUser);
            if (updateUser.Succeeded) {
                return RedirectToAction("Bilgilerim", "Profilim");
            }

            return View();

        }

        public async Task<IActionResult> BegendigimIlanlar()
        {
            var currentUser = await userManager.FindByNameAsync(User.Identity!.Name!);

            LikeIlanViewModel likeIlanViewModel = new LikeIlanViewModel();

            kategorilerIlanlarUrunlerUser.begendigimTMPs = (from p in ılanlarManager.TGetAll().ToList()
                          join j in begeniManager.TGetAll().Where(x=> x.BegenenKullaniciId == currentUser.Id).ToList()
                            on p.Id equals j.IlanId
                          join e in kategorilerManager.TGetAll().ToList()
                           on p.KategorilerId equals e.Id
                          join k in urunlerManager.TGetAll().ToList()
                            on p.UrunlerId equals k.Id
                          select new BegendigimIlanlarTMP
                          {
                              Id = p.Id,
                              IlanAd = p.IlanAd,
                              Aciklama = p.Aciklama,
                              Fiyat = p.Fiyat, 
                              KategroiAd = e.KategoriAd,
                              UrunCesiti = k.UrunCesiti,
                              FotoUrl2 = p.FotoUrl2
                          });
            

            return View(kategorilerIlanlarUrunlerUser);
        }
    }
}
