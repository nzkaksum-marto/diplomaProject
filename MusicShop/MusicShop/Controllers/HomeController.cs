﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

using MusicShop.Core.Contracts;
using MusicShop.Models;
using MusicShop.Models.Product;

using System.Diagnostics;

namespace MusicShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;

        public HomeController(ILogger<HomeController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }
        
        [AllowAnonymous]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Console.WriteLine($"Changing culture to {culture}");
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName, 
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions
                {
                    Expires = DateTimeOffset.UtcNow.AddYears(1),
                    IsEssential = true 
                }
            );

            return LocalRedirect(returnUrl);
        }

        public IActionResult Index()
        {
            List<ProductIndexVM> products = _productService.GetProducts()
                .Select(product => new ProductIndexVM
                {
                    Id = product.Id,
                    ProductName = product.ProductName,
                    BrandId = product.BrandId,
                    BrandName = product.Brand.BrandName,
                    CategoryId = product.CategoryId,
                    CategoryName = product.Category.CategoryName,
                    Picture = product.Picture,
                    Quantity = product.Quantity,
                    Price = product.Price,
                    Discount = product.Discount

                }).ToList();
            return this.View(products);
        }

        public IActionResult Contacts()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
