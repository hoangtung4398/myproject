using Mango.Web.Models;

namespace Mango.Web.Service.IService
{
    public interface ICouponService
    {
        Task<ResponseDto> GetCouponAsync(int couponId);
        Task<ResponseDto> GetAllCouponAsync();
        Task<ResponseDto> GetCouponbyCodeAsync(string couponCode);
        Task<ResponseDto> CreateCouponAsync(Coupon coupon);
        Task<ResponseDto> UpdateCouponAsync(Coupon coupon);
        Task<ResponseDto> DeleteCouponAsync(int couponId);
    }
}
