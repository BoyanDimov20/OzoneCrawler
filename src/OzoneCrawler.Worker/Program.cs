using HtmlAgilityPack;
using OzoneCrawler.Data;
using OzoneCrawler.Core;
using OzoneCrawler.Core.Services;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace OzoneCrawler.Worker
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var dbContext = new ApplicationDbContext();
            var productService = new ProductService(dbContext);
            using var httpClient = new HttpClient();

            const string BaseUrl = "https://www.ozone.bg";

            foreach (var section in OzoneSection.Sections)
            {
                var htmlResult = await httpClient.GetAsync($"{BaseUrl}{section}");

                var htmlDocument = new HtmlDocument();
                htmlDocument.LoadHtml(htmlResult.Content.ReadAsStringAsync().GetAwaiter().GetResult());

                var articles = htmlDocument.DocumentNode
                    .SelectSingleNode("//section")
                    .SelectNodes("//article");

                foreach (var article in articles)
                {
                    var product = Crawler.GetProductByHtmlNode(article);

                    var result = await productService.AddProductAsync(product);
                    await productService.SaveChangesAsync();

                    Console.WriteLine($"{product.ProductName}: {product.DiscountPrice} - {product.Price} ({result.ToString()})");
                }
                Thread.Sleep(2000);
            }
            
            
            
        }
    }
}
