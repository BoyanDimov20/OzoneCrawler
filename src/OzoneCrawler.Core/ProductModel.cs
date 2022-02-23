namespace OzoneCrawler.Core
{
    public class ProductModel
    {
        public bool IsValid { get; set; } = true;

        public string ProductName { get; set; }

        public string Discount { get; set; }

        public string DiscountPrice { get; set; }

        public string Price { get; set; }

        public string ImageUrl { get; set; }
    }
}
