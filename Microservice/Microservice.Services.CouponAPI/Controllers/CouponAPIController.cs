using AutoMapper;
using Microservice.Services.CouponAPI.Data;
using Microservice.Services.CouponAPI.DTO;
using Microservice.Services.CouponAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Microservice.Services.CouponAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponAPIController : ControllerBase
    {
        private readonly CouponDbContext dbContext;
        private readonly IMapper mapper;
        private ResponseDTO response;

        public CouponAPIController(CouponDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            response = new ResponseDTO();
        }

        [HttpGet]
        public async Task<ResponseDTO> Get()
        {
            try
            {
                List<Coupon> coupons = await dbContext.Coupons.ToListAsync();
                response.Result = mapper.Map<List<CouponDTO>>(coupons);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ResponseDTO> Get(int id)
        {
            try
            {
                Coupon? coupon = await dbContext.Coupons.FirstOrDefaultAsync(it => it.CouponId == id);
                response.Result = mapper.Map<CouponDTO>(coupon);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;  
            }
            return response;
        }
    }
}
