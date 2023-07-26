using AutoMapper;
using Microservice.Services.CouponAPI.DTO;
using Microservice.Services.CouponAPI.Models;

namespace Microservice.Services.CouponAPI.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Coupon, CouponDTO>().ReverseMap();
        }
    }
}
