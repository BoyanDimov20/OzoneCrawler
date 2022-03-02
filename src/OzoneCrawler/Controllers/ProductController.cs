using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OzoneCrawler.Core;
using OzoneCrawler.Core.Interfaces;
using OzoneCrawler.Core.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzoneCrawler.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService productService;

        public IConfiguration Configuration { get; }

        public ProductController(ILogger<ProductController> logger, IConfiguration configuration, IProductService productService)
        {
            _logger = logger;
            Configuration = configuration;
            this.productService = productService;
        }

        [HttpGet]
        public async Task<List<ProductModel>> Get(string search)
        {
            var result = productService.GetProductsByNameAsync(search).GetAwaiter().GetResult().ToList();
            if (string.IsNullOrEmpty(search))
            {
                result.Take(50).ToList();
            }

            return result;
        }
    }
}
