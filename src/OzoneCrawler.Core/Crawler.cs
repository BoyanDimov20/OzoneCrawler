using HtmlAgilityPack;
using OzoneCrawler.Core.Constants;
using OzoneCrawler.Core.Models;
using OzoneCrawler.Data;
using System;
using System.Linq;

namespace OzoneCrawler.Core
{
    public class Crawler
    {
        public static ProductModel GetProductByHtmlNode(HtmlNode node)
        {
            var oldPrice = string.Empty;
            var newPrice = string.Empty;
            var productName = string.Empty;
            var discount = string.Empty;
            var imageUrl = string.Empty;

            try
            {
                var root = node.SelectSingleNode("a");

                imageUrl = root.SelectSingleNode("div/img").GetAttributeValue("data-original", "");
                discount = root.SelectSingleNode("div/span/span")?.InnerText.Trim();

                productName = root.SelectSingleNode("h2").InnerText.Trim();

                var prices = root.SelectSingleNode("p/span").SelectNodes("span");
                oldPrice = prices[0].InnerText.Trim();
                newPrice = prices[1].InnerText.Trim();
            }
            catch (System.Exception)
            {
                return new ProductModel
                {
                    IsValid = false
                };
            }
            

            return new ProductModel
            {
                Discount = discount,
                ProductName = productName,
                DiscountPrice = newPrice,
                Price = oldPrice,
                ImageUrl = imageUrl
            };
        }

        public static ProductCategory GetProductCategoryBySection(string section)
        {
            var ozoneSection = typeof(OzoneSection)
                .GetFields()
                .FirstOrDefault(x => (string) x.GetRawConstantValue() == section);

            return Enum.Parse<ProductCategory>(ozoneSection.Name);
        }
    }
}
