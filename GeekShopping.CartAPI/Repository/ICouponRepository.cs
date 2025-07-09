using GeekShopping.CartAPI.Data.ValueObjects;

namespace GeekShopping.CartAPI.Repository;

public interface ICouponRepository
{
    Task<CouponVO> GetCouopon(string couponCode, string token);
}
