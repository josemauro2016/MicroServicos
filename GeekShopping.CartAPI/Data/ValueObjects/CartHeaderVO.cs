﻿namespace GeekShopping.CartAPI.Data.ValueObjects
{
    public class CartHeaderVO
    {
        public long Id { get; set; }

        public string? UserId { get; set; }

        public string? CouponCode { get; set; }
    }
}
