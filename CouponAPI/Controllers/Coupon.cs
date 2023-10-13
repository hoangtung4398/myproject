using CouponAPI.Models;
using CouponAPI.Models.Data;
using CouponAPI.Models.Dto;
using CouponAPI.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace CouponAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponController : ControllerBase
    {
        private readonly ICouponRepository CouponRepo;
        private ResponseDto response;
        public CouponController(AppDbcontext context, ICouponRepository couponRepository)
        {
            CouponRepo = couponRepository;
            this.response = new ResponseDto();

        }

        [HttpGet]
        [Route("Getbyid/{id:int}")]
        public async Task<ResponseDto> GetbyidAsync(int id)
        {
            try
            {
                var result = CouponRepo.Get(coupon => coupon.CouponId == id);

                response.Result = result;

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
        [HttpPost]
        [Route("Create")]
        public async Task<ResponseDto> Creat([FromBody] Coupon coupon)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CouponRepo.Add(coupon);
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
        [HttpGet]
        [Route("Getall")]
        public async Task<ResponseDto> Getall()
        {
            try
            {
                var result = CouponRepo.GetAll();

                response.Result = result;

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
        [HttpPut]
        [Route("Update")]
        public async Task<ResponseDto> Update(Coupon coupon)
        {
            try
            {
                var coupon1 = CouponRepo.Get(i => i.CouponId == coupon.CouponId);
                if (coupon1 != null)
                {
                    CouponRepo.Update(coupon);
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
        [HttpDelete]
        [Route("Delete")]
        public async Task<ResponseDto> Delete(Coupon coupon)
        {
            try
            {

                if (coupon != null)
                {
                    CouponRepo.Delete(coupon);
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

    }
}
