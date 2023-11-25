using AutoMapper;
using CouponAPI.Models;
using CouponAPI.Models.Data;
using CouponAPI.Repository.IRepository;

namespace CouponAPI.Repository
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
