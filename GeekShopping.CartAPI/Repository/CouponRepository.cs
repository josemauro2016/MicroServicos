﻿using GeekShopping.CartAPI.Data.ValueObjects;
using System.Net;
using System.Net.Http.Headers;
using System.Text.Json;

namespace GeekShopping.CartAPI.Repository;

public class CouponRepository : ICouponRepository
{

    private readonly HttpClient _client;

    public CouponRepository(HttpClient client)
    {
        _client = client;
    }

    public async Task<CouponVO> GetCouopon(string couponCode, string token)
    {
        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var response = await _client.GetAsync($"/api/Coupon/{couponCode}");
        var content = await response.Content.ReadAsStringAsync();
        if(response.StatusCode != HttpStatusCode.OK) return new CouponVO();
        return JsonSerializer.Deserialize<CouponVO>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
    }
}
