using System.ComponentModel.DataAnnotations;

namespace Microservice.Services.CouponAPI.Models
{
    public class Coupon
    {
        [Key]
        public int CouponId { get; set; }

        [Required]
        public required string CouponCode { get; set; }

        [Required]
        public required double DiscountAmount { get; set; }

        public int MinAmount { get; set; }
    }
}
