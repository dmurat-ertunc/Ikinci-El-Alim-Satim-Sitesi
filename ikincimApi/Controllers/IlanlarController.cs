using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ikincimApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IlanlarController : ControllerBase
    {
        private readonly IlanlarService ılanlarService;
        private readonly IKategorilerService kategorilerService;

        public IlanlarController(IlanlarService ılanlarService, IKategorilerService kategorilerService)
        {
            this.ılanlarService = ılanlarService;
            this.kategorilerService = kategorilerService;
        }

        [HttpGet]
        public IActionResult IlanlarList()
        {
            var values = ılanlarService.TGetAll();
            return Ok(values);
        }

        
    }
}
