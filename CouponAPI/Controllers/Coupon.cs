using AutoMapper;
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
        private readonly ICouponRepository _couponRepo;
        private readonly ResponseDto _response;
        private readonly IMapper _mapper;
        public CouponController(ICouponRepository couponRepository, IMapper mapper)
        {
            _mapper = mapper;
            _couponRepo = couponRepository;
            this._response = new ResponseDto();

        }

        [HttpGet]
        [Route("Getbyid/{id:int}")]
        public async Task<ResponseDto> GetbyidAsync(int id)
        {
            try
            {
                var result = _couponRepo.Get(coupon => coupon.CouponId == id);
                

                _response.Result = result;

            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
        [HttpPost]
        [Route("Create")]
        public async Task<ResponseDto> Creat([FromBody] CouponDto coupon)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var insertCoupon = _mapper.Map<Coupon>(coupon);
                    _couponRepo.Add(insertCoupon);
                }
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
        [HttpGet]
        [Route("Getall")]
        public async Task<ResponseDto> Getall()
        {
            try
            {
                var result = _couponRepo.GetAll();

                _response.Result = result;

            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
        [HttpPut]
        [Route("Update")]
        public async Task<ResponseDto> Update(Coupon coupon)
        {
            try
            {
                var coupon1 = _couponRepo.Get(i => i.CouponId == coupon.CouponId);
                if (coupon1 != null)
                {
                    _couponRepo.Update(coupon);
                }
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
        [HttpDelete]
        [Route("Delete")]
        public async Task<ResponseDto> Delete(Coupon coupon)
        {
            try
            {

                if (coupon != null)
                {
                    _couponRepo.Delete(coupon);
                }
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

    }
}
