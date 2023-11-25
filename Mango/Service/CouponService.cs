using Mango.Web.Models;
using Mango.Web.Service.IService;
using Mango.Web.Utility;

namespace Mango.Web.Service
{
    public class CouponService : ICouponService
    {
        public IBaseService _BaseService;
        public CouponService(IBaseService baseService)
        {
            _BaseService = baseService;
        }
        public CouponService() { }
        public async Task<ResponseDto> CreateCouponAsync(CouponDto coupon)
        {
            return await _BaseService.SendAsync(new Requestmsg()
            {
                ApiType = Utility.SD.ApiType.POST,
                Data = coupon,
                Url = SD.CouponAPIbase + "/api/Coupon/Create"

            });
        }

        public async Task<ResponseDto> DeleteCouponAsync(Coupon coupon)
        {
            return await _BaseService.SendAsync(new Requestmsg()
            {
                ApiType = Utility.SD.ApiType.DELETE,
                Data = coupon,
                Url = SD.CouponAPIbase + "/api/Coupon/Delete"

            });
        }

        public async Task<ResponseDto> GetAllCouponAsync()
        {
            return await _BaseService.SendAsync(new Requestmsg()
            {
                ApiType = Utility.SD.ApiType.GET,
                Url = SD.CouponAPIbase + "/api/Coupon/Getall"

            });
        }

        public async Task<ResponseDto> GetCouponAsync(int couponId)
        {
            return await _BaseService.SendAsync(new Requestmsg()
            {
                ApiType = Utility.SD.ApiType.GET,
                Url = SD.CouponAPIbase + "/api/Coupon/Getbyid/" + couponId

            });
        }

        public async Task<ResponseDto> GetCouponbyCodeAsync(string couponCode)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDto> UpdateCouponAsync(Coupon coupon)
        {
            throw new NotImplementedException();
        }
    }
}
