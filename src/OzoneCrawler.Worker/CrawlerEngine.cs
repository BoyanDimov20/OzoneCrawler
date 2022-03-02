using HtmlAgilityPack;
using OzoneCrawler.Core;
using OzoneCrawler.Core.Constants;
using OzoneCrawler.Core.Interfaces;
using OzoneCrawler.Worker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace OzoneCrawler.Worker
{
    public class CrawlerEngine
    {
        private readonly IProductService productService;

        private const string BaseUrl = "https://www.ozone.bg";

        public CrawlerEngine(IProductService productService)
        {
            this.productService = productService;
        }
        public async Task Run(Statistics statistics = Statistics.None)
        {
            
            using var httpClient = new HttpClient();


            var changes = new List<ProductChange>();
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
                    product.Category = Crawler.GetProductCategoryBySection(section);


                    var result = await productService.AddProductAsync(product);
                    await productService.SaveChangesAsync();

                    if (statistics == Statistics.Changes)
                    {
                        changes.Add(result);
                    }

                    if (result == ProductChange.Added || result == ProductChange.Updated)
                    {
                        Console.WriteLine($"{product.ProductName}: {product.DiscountPrice} - {product.Price} ({result.ToString()})");
                    }
                }
                Thread.Sleep(2000);
            }

            // Statistics
            if (statistics == Statistics.Changes)
            {
                foreach (var enumValue in Enum.GetValues<ProductChange>())
                {
                    Console.WriteLine($"{enumValue}: {changes.Count(x => x == enumValue)}");
                }
            }
            
        }
    }
}
