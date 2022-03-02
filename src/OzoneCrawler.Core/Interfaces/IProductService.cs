using OzoneCrawler.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OzoneCrawler.Core.Interfaces
{
    public interface IProductService
    {
        public Task<ProductChange> AddProductAsync(ProductModel product);
        public Task SaveChangesAsync();
        public Task<List<ProductModel>> GetProductsAsync();
        public Task<List<ProductModel>> GetProductsByNameAsync(string value);
    }
}
