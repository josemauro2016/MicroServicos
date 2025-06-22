namespace GeekShopping.Web.Models;

public class CartVielModel
{
    public CartHeaderViewModel CartHeader { get; set; }
    public IEnumerable<CartDetailViewModel> CartDetails { get; set; }
}
