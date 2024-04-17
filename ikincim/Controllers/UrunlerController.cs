using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace ikincim.Controllers
{
    public class UrunlerController : Controller
    {
        UrunlerManager urunlerManager = new UrunlerManager(new EfUrunlerDal());
        IlanlarManager ilanlarManager = new IlanlarManager(new EfIlanlarDal());
        KategorilerManager kategorilerManager = new KategorilerManager(new EfKategorilerDal());
        KategorilerUrunlerIlanlar kategorilerUrunlerIlanlar = new KategorilerUrunlerIlanlar();

        public IActionResult Index(int id)
        {
            kategorilerUrunlerIlanlar.kategorilers = kategorilerManager.TGetAll().Where(x => x.Id == id).ToList();
            kategorilerUrunlerIlanlar.kategorilers2 = kategorilerManager.TGetAll().ToList();
            kategorilerUrunlerIlanlar.kategorilers3 = kategorilerManager.TGetAll().ToList();
            kategorilerUrunlerIlanlar.urunlers = urunlerManager.TGetAll().ToList();
            kategorilerUrunlerIlanlar.ilanlars = ilanlarManager.TGetAll().Where(x => x.KategorilerId == id && x.AktifSatildi == 0).ToList();
            return View(kategorilerUrunlerIlanlar);
        }
    }
}
