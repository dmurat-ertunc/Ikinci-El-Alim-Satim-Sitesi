using AutoMapper;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using ikincim.Models;
using Microsoft.AspNetCore.Mvc;

namespace ikincim.Controllers
{
    public class HomePageController : Controller
    {
        //https://localhost:7294/HomePage/Index
        KategorilerManager kategorilerManager = new KategorilerManager(new EfKategorilerDal());
        IlanlarManager ılanlarManager = new IlanlarManager(new EfIlanlarDal());
        UrunlerManager urunlerManager = new UrunlerManager(new EfUrunlerDal());
        KategorilerUrunlerIlanlar kategorilerUrunlerIlanlar = new KategorilerUrunlerIlanlar();

        public IActionResult Index(int id)
        {
            //kategorilerUrunlerIlanlar.urunlers = urunlerManager.TGetAll().Where(x => x.KategorilerId == id).ToList();
            kategorilerUrunlerIlanlar.kategorilers2 = kategorilerManager.TGetAll().ToList();
            kategorilerUrunlerIlanlar.urunlers = urunlerManager.TGetAll().ToList();
            kategorilerUrunlerIlanlar.kategorilers =  kategorilerManager.TGetAll().ToList();
            kategorilerUrunlerIlanlar.ilanlars = ılanlarManager.TGetAll().Take(10).Where(x => x.AktifSatildi == 0).ToList();

            return View(kategorilerUrunlerIlanlar);
        }
    }
}
