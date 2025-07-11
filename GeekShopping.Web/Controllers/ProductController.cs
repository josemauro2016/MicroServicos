﻿using GeekShopping.Web.Models;
using GeekShopping.Web.Services.IServices;
using GeekShopping.Web.Utils;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.Web.Controllers;

public class ProductController : Controller
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService; //?? throw new ArgumentNullException(nameof(productService));
    }

    [HttpGet]
    public async Task<IActionResult> ProductIndex()
    {
        var products = await _productService.FindAllProducts("");
        return View(products);
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> ProductCreate()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> ProductCreate(ProductViewModel model)
    {
        if (ModelState.IsValid)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var response = await _productService.CreateProduct(model, token);
            if (response != null) return RedirectToAction(nameof(ProductIndex));
        }
        return View(model);
    }

    
    [HttpGet]
    public async Task<IActionResult> ProductUpdate(int id)
    {
        var token = await HttpContext.GetTokenAsync("access_token");
        var model = await _productService.FindProductById(id, token);
        if(model != null) return View(model);
        return NotFound();
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> ProductUpdate(ProductViewModel model)
    {
        if (ModelState.IsValid)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var response = await _productService.UpdateProduct(model, token);
            if (response != null) return RedirectToAction(nameof(ProductIndex));
        }
        return View(model);
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> ProductDelete(int id)
    {
        var token = await HttpContext.GetTokenAsync("access_token");
        var model = await _productService.FindProductById(id, token);
        if (model != null) return View(model);
        return NotFound();
    }

    [Authorize(Roles = Role.Admin)]
    [HttpPost]
    public async Task<IActionResult> ProductDelete(ProductViewModel model)
    {
        var token = await HttpContext.GetTokenAsync("access_token");
        var response = await _productService.DeleteProductgById(model.Id, token);
        if (response) return RedirectToAction(nameof(ProductIndex));
        return View(model);
    }

}
