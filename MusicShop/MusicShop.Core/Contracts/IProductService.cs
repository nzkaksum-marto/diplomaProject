﻿using Microsoft.AspNetCore.Mvc.ModelBinding;

using MusicShop.Infrastructure.Data.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Core.Contracts
{
    public interface IProductService
    {
        bool Create(string name,string description, int brandId, int categoryId, string picture, int quantity, decimal price, decimal discount);
        bool Update(int productId, string name,  string description,int brandId, int categoryId, string picture, int quantity, decimal price, decimal discount);
        List<Product> GetProducts();
        Product GetProductById(int productId);
        bool RemoveById(int productId);

        List<Product> GetProducts(string searchStringCategoryName, string searchStringBrandName);
    }
}
