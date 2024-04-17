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
    public class IlanVerController : Controller
    {
        KategorilerManager kategorilerManager = new KategorilerManager(new EfKategorilerDal());
        IlanlarManager ılanlarManager = new IlanlarManager(new EfIlanlarDal());
        UrunlerManager urunlerManager = new UrunlerManager(new EfUrunlerDal());
        KategorilerIlanlarUrunlerUser kategorilerIlanlarUrunlerUser = new KategorilerIlanlarUrunlerUser();


        private readonly UserManager<AppUser> userManager;

        public IlanVerController(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }


        [Authorize]
        [HttpGet]
        public IActionResult Index()
        {
            kategorilerIlanlarUrunlerUser.urunlers = urunlerManager.TGetAll();
            kategorilerIlanlarUrunlerUser.kategorilers = kategorilerManager.TGetAll();
            return View(kategorilerIlanlarUrunlerUser);
        }

        [HttpPost]
        public  IActionResult Index(AddIlanViewModel addIlanViewModel,IEnumerable<IFormFile> files)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View();
            //}
            Ilanlar ılanlar = new Ilanlar();
            if(files != null)
            {

                var extension = Path.GetExtension(files.ToArray()[0].FileName);
                var newImageName = files.ToArray()[0].FileName;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/FotoUrl/" ,newImageName);
                var stream = new FileStream(location, FileMode.Create);
                //files.ToArray()[0].CopyTo(stream);
                //ılanlar.FotoUrl1 = newImageName;
            }
            

            //var vars = new Ilanlar()
            //{

            //    UrunlerId = p.IlanId,

            //};
            return View();
        }

        private void SaveImage(IEnumerable<IFormFile> formFiles)
        {
            foreach (var formFile in formFiles)
            {
                byte[] picture = null;
                using (var ms = new MemoryStream())
                {
                    formFile.CopyTo(ms);
                    picture = ms.ToArray();
                }
                var fullpath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/FotoUrl/", formFile.FileName);

                if (System.IO.File.Exists(fullpath))
                {
                    System.IO.File.Delete(fullpath);
                }
                System.IO.File.WriteAllBytes(fullpath, picture);
            }

        }

    }
}
