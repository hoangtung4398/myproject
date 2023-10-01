using AutoMapper;
using CouponAPI.Models;
using CouponAPI.Models.Data;
using CouponAPI.Models.Dto;

namespace CouponAPI.Repository.IRepository
{
    public class CouponRepository : Repository<Coupon>, ICouponRepository
    {
        private readonly AppDbcontext _db;
        private IMapper _mapper;

        public CouponRepository(AppDbcontext db) :base(db)
        {
            _db = db;
        }

    }
}
