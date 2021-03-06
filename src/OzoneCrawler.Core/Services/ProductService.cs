using Microsoft.EntityFrameworkCore;
using OzoneCrawler.Core.Interfaces;
using OzoneCrawler.Core.Models;
using OzoneCrawler.Data;
using OzoneCrawler.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzoneCrawler.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext dbContext;

        public ProductService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<ProductChange> AddProductAsync(ProductModel product)
        {
            ProductChange productChanges = default;

            if (!this.dbContext.Products.Any(x => x.ProductName == product.ProductName &&
            x.Price == product.Price &&
            x.Discount == x.Discount &&
            x.DiscountPrice == product.DiscountPrice) && product.IsValid)
            {
                productChanges = ProductChange.Added;
                if (this.dbContext.Products.Any(x => x.ProductName == product.ProductName))
                {
                    productChanges = ProductChange.Updated;
                }
                await dbContext.AddAsync(new Product 
                {
                    ProductName = product.ProductName,
                    Discount = product.Discount,
                    DiscountPrice = product.DiscountPrice,
                    ImageUrl = product.ImageUrl,
                    Price = product.Price,
                    Category = product.Category
                });
            }
            else
            {
                productChanges = product.IsValid ? ProductChange.AlreadyExists : ProductChange.InvalidItem;
            }

            return productChanges;
        }
        public async Task SaveChangesAsync()
        {
            await dbContext.SaveChangesAsync();
        }

        public Task<List<ProductModel>> GetProductsAsync()
        {
            return this.dbContext.Products.Select(x => new ProductModel
            {
                Discount = x.Discount,
                DiscountPrice = x.DiscountPrice,
                ImageUrl = x.ImageUrl,
                Price = x.Price,
                ProductName = x.ProductName
            }).ToListAsync();
        }

        public Task<List<ProductModel>> GetProductsByNameAsync(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return GetProductsAsync();
            }

            return this.dbContext.Products
                .Where(x => x.ProductName.Contains(value))
                .Select(x => new ProductModel
            {
                Discount = x.Discount,
                DiscountPrice = x.DiscountPrice,
                ImageUrl = x.ImageUrl,
                Price = x.Price,
                ProductName = x.ProductName
            }).ToListAsync();
        }

        public Task<int> ProductCount()
        {
            return this.dbContext.Products.CountAsync();
        }
    }
}
