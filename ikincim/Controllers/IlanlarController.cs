using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace ikincim.Controllers
{
    public class IlanlarController : Controller
    {
        UrunlerManager urunlerManager = new UrunlerManager(new EfUrunlerDal());
        IlanlarManager ilanlarManager = new IlanlarManager(new EfIlanlarDal());
        KategorilerManager kategorilerManager = new KategorilerManager(new EfKategorilerDal());
        KategorilerUrunlerIlanlar kategorilerUrunlerIlanlar = new KategorilerUrunlerIlanlar();
        public IActionResult Index(int id)
        {
            int kategorıId = urunlerManager.TGetById(id).KategorilerId;
            kategorilerUrunlerIlanlar.kategorilers = kategorilerManager.TGetAll().Where(x => x.Id == kategorıId).ToList();
            kategorilerUrunlerIlanlar.kategorilers2 = kategorilerManager.TGetAll().ToList();
            kategorilerUrunlerIlanlar.kategorilers3 = kategorilerManager.TGetAll().ToList();
            kategorilerUrunlerIlanlar.urunlers2 = urunlerManager.TGetAll().Where(x => x.Id == id).ToList();
            kategorilerUrunlerIlanlar.urunlers = urunlerManager.TGetAll().ToList();
            kategorilerUrunlerIlanlar.ilanlars = ilanlarManager.TGetAll().Where(x => x.UrunlerId == id && x.AktifSatildi == 0).ToList();
            return View(kategorilerUrunlerIlanlar);
        }
        
    }
}
