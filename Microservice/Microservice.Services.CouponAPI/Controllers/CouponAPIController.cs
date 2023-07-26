using Microservice.Services.CouponAPI.Data;
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

        public CouponAPIController(CouponDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<Coupon> coupons = await dbContext.Coupons.ToListAsync();
                return Ok(coupons);
            }
            catch (Exception ex)
            {

            }
            return BadRequest();
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                Coupon? coupon = await dbContext.Coupons.FirstOrDefaultAsync(it => it.CouponId == id);

                if (coupon == null)
                {
                    return NotFound();
                }

                return Ok(coupon);
            }
            catch (Exception ex)
            {

            }
            return BadRequest();
        }
    }
}
