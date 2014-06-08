using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fipe.Crawler.Tests
{
    [TestClass]
    public class BrandCrawlerTests
    {
        [TestMethod]
        public void FindAllBrandsShouldBeReturnAListOffBrands()
        {
            var crawler = new BrandsCrawler();
            var brands = crawler.FindAllBrands();

            Assert.IsTrue(brands.Any());
        }
    }
}
