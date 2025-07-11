﻿using GeekShopping.CartAPI.Data.ValueObjects;

namespace GeekShopping.CartAPI.Repository;

public interface ICartRepository
{
    Task<CartVO> FindCartByUserId(string userId);
    Task<CartVO> SaveOrUpdateCart(CartVO vo);
    Task<bool> RemoveFromCart(long cartDetailsId);
    Task<bool> ApplyCoupon(string userId, string couponCoude);
    Task<bool> RemoveCoupon(string userId);
    Task<bool> ClearCart(string userId);
}
