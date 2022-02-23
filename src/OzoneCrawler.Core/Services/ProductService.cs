using OzoneCrawler.Data;
using OzoneCrawler.Data.Models;
using System.Linq;
using System.Threading.Tasks;

namespace OzoneCrawler.Core.Services
{
    public class ProductService
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
                    Price = product.Price
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
    }
}
