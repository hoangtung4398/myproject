using AutoMapper;
using CouponAPI.Models;
using CouponAPI.Models.Data;

namespace CouponAPI.Repository.IRepository
{
    public class CouponRepository : Repository<Coupon>, ICouponRepository
    {
        private readonly AppDbcontext _db;
        private IMapper _mapper;

        public CouponRepository(AppDbcontext db) : base(db)
        {
            _db = db;
        }

    }
}
