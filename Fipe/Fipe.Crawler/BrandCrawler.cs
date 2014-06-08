using System.Collections.Generic;
using System.Linq;
using Fipe.Domain;
using HtmlAgilityPack;

namespace Fipe.Crawler
{
    public class BrandCrawler : IBrandCrawler
    {
        private const string BaseAddress = "http://fipe.org.br/web/indices/veiculos/default.aspx?p=51";

        public IEnumerable<Brand> FindAllBrands()
        {
            var document = GetDocument();

            var options = GetBrandsOptions(document);

            var brandsDictionary = ParseBrandsOptions(options);

            return brandsDictionary.Select(item => new Brand(item.Value, int.Parse(item.Key))).ToList();
        }

        private static IEnumerable<KeyValuePair<string, string>> ParseBrandsOptions(IEnumerable<HtmlNode> options)
        {
            var items = new Dictionary<string, string>();

            foreach (var option in options)
            {
                var value = option.Attributes["value"].Value;
                if (value == "0") continue;

                var text = option.NextSibling.InnerText;

                items.Add(value, text);
            }

            return items;
        }

        private static IEnumerable<HtmlNode> GetBrandsOptions(HtmlDocument document)
        {
            var select = document.DocumentNode.Descendants("select").FirstOrDefault(d => d.Id == "ddlMarca");

            return @select != null ? @select.Descendants("option") : new List<HtmlNode>();
        }

        private static HtmlDocument GetDocument()
        {
            var web = new HtmlWeb();
            var document = web.Load(BaseAddress);

            return document;
        }
    }
}
