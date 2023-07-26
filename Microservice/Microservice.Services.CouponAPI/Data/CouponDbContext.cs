using Microservice.Services.CouponAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Microservice.Services.CouponAPI.Data
{
    public class CouponDbContext : DbContext
    {
        public CouponDbContext(DbContextOptions<CouponDbContext> options) : base(options)
        {
        }

        public DbSet<Coupon> Coupons { get; set; }
    }
}
