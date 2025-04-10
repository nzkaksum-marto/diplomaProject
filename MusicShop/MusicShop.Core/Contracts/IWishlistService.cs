using MusicShop.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Core.Contracts
{
    public interface IWishlistService
    {
        List<Wishlist> GetWishListByUserId(string userId);
        bool AddToWishList(string userId, int productId);
        bool RemoveFromWishList(string userId, int productId);
    }
}
