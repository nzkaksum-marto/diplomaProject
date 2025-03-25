using MusicShop.Core.Contracts;
using MusicShop.Data;
using MusicShop.Infrastructure.Data.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Core.Services
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _context;
        public OrderService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Create(int productId, string userId, int quantity)
        {
            var product = this._context.Products.SingleOrDefault(x => x.Id == productId);
            if (product == null) { return false; }

            Order item = new Order
            {
                OrderDate = DateTime.Now,
                ProductId = productId,
                UserId = userId,
                Quantity = quantity,
                Price = product.Price,
                Discount = product.Discount,
            };
            product.Quantity -= quantity;
            this._context.Products.Update(product);
            this._context.Orders.Add(item);
            return _context.SaveChanges() != 0;
        }
        public List<Order> GetOrders()
        {
            return _context.Orders.OrderByDescending(x => x.OrderDate).ToList();
        }

        public List<Order> GetOrdersByUser(string userId)
        {
            return _context.Orders.Where(x => x.UserId == userId)
                .OrderByDescending(x => x.OrderDate).ToList();
        }
        public bool CreateOrderFromCart(List<ShoppingCartItem> cartItems)
        {
            // Create order for each cart item
            foreach (var item in cartItems)
            {
                var order = new Order
                {
                    OrderDate = DateTime.Now,
                    ProductId = item.ProductId,
                    UserId = item.UserId,
                    Quantity = item.Quantity,
                    Price = item.Product.Price,
                    Discount = item.Product.Discount,
                };
                _context.Orders.Add(order);
                // Update product quantity
                var product = _context.Products.Find(item.ProductId);
                product.Quantity -= item.Quantity;
                _context.Products.Update(product);
            }
            return _context.SaveChanges() != null;

        }
    }
}
