﻿using GeekShopping.Web.Models;
using GeekShopping.Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.Web.Controllers;

public class ProductController : Controller
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService ?? throw new ArgumentNullException(nameof(productService));
    }

    public async Task<IActionResult> ProductIndex()
    {
        var products = await _productService.FindAllProducts();
        return View(products);
    }

    [HttpGet]
    public async Task<IActionResult> ProductCreate()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> ProductCreate(ProductModel model)
    {
        if (ModelState.IsValid)
        {
            var response = await _productService.CreateProduct(model);
            if (response != null) return RedirectToAction(nameof(ProductIndex));
        }
        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> ProductUpdate(int id)
    {
        var model = await _productService.FindProductById(id);
        if(model != null) return View(model);
        return NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> ProductUpdate(ProductModel model)
    {
        if (ModelState.IsValid)
        {
            var response = await _productService.UpdateProduct(model);
            if (response != null) return RedirectToAction(nameof(ProductIndex));
        }
        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> ProductDelete(int id)
    {
        var model = await _productService.FindProductById(id);
        if (model != null) return View(model);
        return NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> ProductDelete(ProductModel model)
    {
        var response = await _productService.DeleteProductgById(model.Id);
        if (response) return RedirectToAction(nameof(ProductIndex));
        return View(model);
    }

}
