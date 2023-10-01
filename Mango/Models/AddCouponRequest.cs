namespace Mango.Web.Models
{
    public class AddCouponRequest
    {
        public string CouponCode { get; set; }
        public double DiscountAmount { get; set; }
        public int MinAmount { get; set; }
    }
}
