using GeekShopping.CouponAPI.Data.ValueObjects;

namespace GeekShopping.CouponAPI.Repository;

public interface ICouponRepository
{
    Task<CouponVO> GetCouoponByCouponCode(string couponCode);
}
