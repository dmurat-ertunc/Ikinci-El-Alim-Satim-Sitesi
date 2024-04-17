using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ikincimApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KategorilerController : ControllerBase
    {
        private readonly IKategorilerService kategorilerService;

        public KategorilerController(IKategorilerService kategorilerService)
        {
            this.kategorilerService = kategorilerService;
        }

        [HttpGet]
        public IActionResult KategoriList()
        {
            var values = kategorilerService.TGetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddKategori(Kategoriler kategoriler)
        {
            var values = new Kategoriler()
            {
                KategoriAd = kategoriler.KategoriAd,
                IconClass = kategoriler.IconClass
            };

            kategorilerService.TAdd(values);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult FindKategori(int id)
        {
            var values = kategorilerService.TGetById(id);
            return Ok(values);
        }
        [HttpPut]
        public IActionResult EditKategori(Kategoriler kategoriler)
        {
            var values = new Kategoriler()
            {
                Id = kategoriler.Id,
                KategoriAd = kategoriler.KategoriAd,
                IconClass = kategoriler.IconClass
            };
            kategorilerService.TUpdate(values);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteKategori(int id)
        {
            var values = kategorilerService.TGetById(id);
            kategorilerService.TDelete(values);
            return Ok();
        }

    }
}
