using Castle.Core.Internal;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicShop.Core.Contracts;
using MusicShop.Models.Wishlist;
using System.Security.Claims;

namespace MusicShop.Controllers
{
    [Authorize]
    public class WishListController : Controller
    {
        private readonly IWishlistService _wishListService;
        private readonly IProductService _productService;

        public WishListController(IWishlistService wishListService, IProductService productService)
        {
            _wishListService = wishListService;
            _productService = productService;
        }

        public IActionResult Index()
        {
            var currentUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var wishList = _wishListService.GetWishListByUserId(currentUserId);
         

            var model = wishList.Select(w => new WishlistDTO
            {
                Id = w.Id,
                ProductId = w.Product.Id,
                ProductName = w.Product.ProductName,
                Picture = w.Product.Picture,
                Price = w.Product.Price
            }).ToList();

            return View(model);
        }
        [HttpPost]
        public IActionResult Add(int productId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            _wishListService.AddToWishList(userId, productId);
            return RedirectToAction("Index");
        }

        public IActionResult Remove(int productId)
        {
            var currentUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            _wishListService.RemoveFromWishList(currentUserId, productId);
            if (currentUserId == null) return NotFound();
            return RedirectToAction(nameof(Index));
        }
    }
}
