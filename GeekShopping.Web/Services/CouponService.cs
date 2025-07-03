using GeekShopping.Web.Models;
using GeekShopping.Web.Services.IServices;
using System.Net.Http.Headers;
using System.Net;
using GeekShopping.Web.Utils;

namespace GeekShopping.Web.Services;

public class CouponService : ICouponService
{

    private readonly HttpClient _clinet;
    public const string BasePath = "api/Coupon";

    public CouponService(HttpClient clinet)
    {
        _clinet = clinet;
    }

    public async Task<CouponViewModel> GetCoupon(string code, string token)
    {
        _clinet.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var response = await _clinet.GetAsync($"{BasePath}/{code}");
        if(response.StatusCode != HttpStatusCode.OK) return new CouponViewModel();
        return await response.ReadContentAs<CouponViewModel>();
    }
}
