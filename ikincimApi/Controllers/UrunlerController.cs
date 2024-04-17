using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ikincimApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrunlerController : ControllerBase
    {
        private readonly IUrunlerService urunlerService;
        private readonly IKategorilerService kategorilerService;

        public UrunlerController(IUrunlerService urunlerService, IKategorilerService kategorilerService)
        {
            this.urunlerService = urunlerService;
            this.kategorilerService = kategorilerService;
        }

        KategorilerUrunlerTMP kategorilerUrunlerTMP = new KategorilerUrunlerTMP();

        [HttpGet]
        public IActionResult UrunlerList()
        {
            var values = (from p in urunlerService.TGetAll().ToList()
                          join e in kategorilerService.TGetAll().ToList()
                               on p.KategorilerId equals e.Id
                          select new KategorilerUrunlerTMP
                          {
                              Id = p.Id,
                              UrunCesiti = p.UrunCesiti,
                              KategoriAd = e.KategoriAd,
                              KategoriId = e.Id,
                          });
            //var values = (from p in urunlerService.TGetAll().ToList()
            //              join e in kategorilerService.TGetAll().ToList()
            //                   on p.KategorilerId equals e.Id
            //              select new KategorilerUrunlerTMP
            //              {
            //                  UrunId = p.Id,
            //                  UrunCesiti = p.UrunCesiti,
            //                  KategoriAd = e.KategoriAd,
            //                  KategoriId = e.Id,
            //              }).Where(x => x.KategoriId == 1).ToList();    kategori id si sadece 1 olanlar
            return Ok(values); 
        }                                 
    }
}
    
