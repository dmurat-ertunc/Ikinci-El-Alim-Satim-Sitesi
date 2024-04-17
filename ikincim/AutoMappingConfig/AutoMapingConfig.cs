using AutoMapper;
using EntityLayer.Concrete;
using ikincim.Models;

namespace ikincim.AutoMappingConfig
{
    public class AutoMapingConfig : Profile
    {
        public AutoMapingConfig()
        {
            CreateMap<AppUser, UserViewModel>().ReverseMap();
        }
    }
}
