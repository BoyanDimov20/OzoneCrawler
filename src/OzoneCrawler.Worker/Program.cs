using OzoneCrawler.Data;
using OzoneCrawler.Core.Services;
using System.Threading.Tasks;
using OzoneCrawler.Worker.Models;

namespace OzoneCrawler.Worker
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var db = new ApplicationDbContext();
            var engine = new CrawlerEngine(new ProductService(db));

            await engine.Run(Statistics.Changes);
        }
    }
}
