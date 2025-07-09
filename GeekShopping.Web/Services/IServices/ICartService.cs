using GeekShopping.Web.Models;

namespace GeekShopping.Web.Services.IServices;

public interface ICartService
{
    Task<CartVielModel> FindCartByUserId(string userId, string token);
    Task<CartVielModel> AddItemToCart(CartVielModel cart, string token);
    Task<CartVielModel> UpdateCart(CartVielModel cart, string token);
    Task<bool> RemoveFromCart(long cartId, string token);

    Task<bool> ApplyCoupon(CartVielModel cart, string token);
    Task<bool> RemoveCoupon(string userId, string token);
    Task<bool> ClearCart(string userId, string token);

    Task<object> Checkout(CartHeaderViewModel cartHeader, string token);
}
