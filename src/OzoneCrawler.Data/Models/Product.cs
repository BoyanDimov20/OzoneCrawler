using System;

namespace OzoneCrawler.Data.Models
{
    public class Product
    {
        public Product()
        {
            Id = Guid.NewGuid().ToString();
            CreatedOn = DateTime.Now;
        }

        public string Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public string ProductName { get; set; }

        public string Discount { get; set; }

        public string DiscountPrice { get; set; }

        public string Price { get; set; }

        public string ImageUrl { get; set; }

        public ProductCategory Category { get; set; }
    }
}
