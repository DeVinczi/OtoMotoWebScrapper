using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HtmlAgilityPack;
using HtmlAgilityPack.CssSelectors.NetCore;

namespace WebScrappingOTOMOTO
{
    public class CarParamsScrapper
    {
        public IEnumerable<CarDetails> CarDetails(CarParams car)
        {
            var web = new HtmlWeb();
            var document = web.Load(car.Href);
            var mainDetails = document.QuerySelectorAll(".offer-summary > span:nth-child(3)");

            foreach (var detail in mainDetails)
            {
                var Year = detail.QuerySelector("span:nth-child(3) > span:nth-child(1)");
                var RoadClock = detail.QuerySelector("span:nth-child(3) > span:nth-child(2)");
                var GasType = detail.QuerySelector("span:nth-child(3) > span:nth-child(3)");
                var CarBody = detail.QuerySelector("span:nth-child(3) > span:nth-child(4)");
                var Money = document.QuerySelector("span.offer-price__number:nth-child(3)");

                var yearSelect = Year.InnerText.Trim();
                var roadClockSelect = RoadClock.InnerText.Trim();
                var convertedRoadClockSelect = roadClockSelect
                    .Remove(roadClockSelect
                    .Count() - 3)
                    .Replace(" ","");
                var convertedRoadClockSelectInt = int.Parse(convertedRoadClockSelect);
                var gasType = GasType.InnerText.Trim();
                var carBody = CarBody.InnerText.Trim();
                var money = Money.InnerText.Trim().Replace(" ","");

                Console.WriteLine($"{yearSelect}\n{convertedRoadClockSelect}\n{gasType}\n{carBody}\n{money}\n");
                yield return new CarDetails(gasType,money, convertedRoadClockSelectInt, yearSelect, carBody);
            }
        }
    }
}
