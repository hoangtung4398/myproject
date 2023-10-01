using System.ComponentModel.DataAnnotations;

namespace CouponAPI.Models.Dto
{
    public class CouponDto 
    { 
    
        public string CouponCode { get; set; }

        public double DiscountAmount { get; set; }
        public int MinAmount { get; set; }
    }
}
