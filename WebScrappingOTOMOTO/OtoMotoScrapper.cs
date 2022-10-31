using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HtmlAgilityPack;
using HtmlAgilityPack.CssSelectors.NetCore;

namespace WebScrappingOTOMOTO
{
    public class OtoMotoScrapper
    {
        private const string BaseUrl = "https://www.otomoto.pl/osobowe/seg-coupe?search%5Bfilter_float_price%3Afrom%5D=15000&search%5Bfilter_float_price%3Ato%5D=30000";

        public IEnumerable<CarParams> GetCars()
        {
            var web = new HtmlWeb();
            var document = web.Load(BaseUrl);


            var linkiAutStrona =
                document.QuerySelectorAll("div:nth-child(1) > h2:nth-child(1) > a:nth-child(1)");

            int i = 1;
            while (i < 10) //to make, finding last page
            {
                var documentnext = web.Load(BaseUrl + $"&page={i++}");

                linkiAutStrona = documentnext.QuerySelectorAll("div:nth-child(1) > h2:nth-child(1) > a:nth-child(1)");
                foreach (var auto in linkiAutStrona)
                {
                    var nazwa = auto.InnerText;
                    var href = auto.QuerySelector("a").Attributes["href"].Value;
                    Console.WriteLine($"{nazwa}\n{href}\n");
                    yield return new CarParams(nazwa, href);
                }
            }
        }
    }
}
