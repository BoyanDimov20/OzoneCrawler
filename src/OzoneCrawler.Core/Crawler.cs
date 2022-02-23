using HtmlAgilityPack;

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
                discount = root.SelectSingleNode("div/span/span")?.InnerHtml;

                productName = root.SelectSingleNode("h2").InnerText;

                var prices = root.SelectSingleNode("p/span").SelectNodes("span");
                oldPrice = prices[0].InnerText;
                newPrice = prices[1].InnerText;
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
    }
}
