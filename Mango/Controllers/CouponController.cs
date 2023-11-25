using Mango.Web.Models;
using Mango.Web.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Mango.Web.Controllers
{
    public class CouponController : Controller
    {
        public ICouponService _couponService;
        public CouponController(ICouponService couponService)
        {
            _couponService = couponService;
        }
        public async Task<IActionResult> CouponIndex()
        {
            List<Coupon> list = new();
            ResponseDto response = await _couponService.GetAllCouponAsync();
            if (response != null)
            {
                list = JsonConvert.DeserializeObject<List<Coupon>>(Convert.ToString(response.Result));
            }
            return View(list);
        }
        [HttpPost]
        public async Task<IActionResult> CouponCreate(CouponDto couponrequest)
        {
            if (ModelState.IsValid)
            {
                ResponseDto response = await _couponService.CreateCouponAsync(couponrequest);
                if (response != null && response.Success)
                {
                    return RedirectToAction(nameof(CouponIndex));
                }
            }
            return View(couponrequest);
        }
        public IActionResult CouponCreate()
        {
            return View();
        }
        public async Task<IActionResult> CouponDelete(int couponId)
        {
            ResponseDto response = await _couponService.GetCouponAsync(couponId);
            var result = new Coupon();
            if (response != null)
            {
                result = JsonConvert.DeserializeObject<Coupon>(Convert.ToString(response.Result));
            }
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> CouponDelete(Coupon coupon)
        {
            ResponseDto response = await _couponService.DeleteCouponAsync(coupon);
            if (response != null && response.Success)
            {
                return RedirectToAction(nameof(CouponIndex));
            }
            return View(coupon);
        }
    }
}
