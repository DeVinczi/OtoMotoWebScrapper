using System.Linq;

using HtmlAgilityPack;

using Newtonsoft.Json;

namespace WebScrappingOTOMOTO
{
    class Program
    { 
        static void Main(string[] args)
        {

            var auta = new OtoMotoScrapper();
            var result = auta.GetCars();
            var details = new CarParamsScrapper();
            var r = new List<AllParams>();

            var k = r.Where(p => p.RoadClock < 120000).Select(p => p);
            foreach (var car in result)
            {

                var aa = details.CarDetails(car);
                foreach (var x in aa)
                {
                    r.Add(new AllParams()
                    {
                        Name = car.Name,
                        Href = car.Href,
                        Money = x.Money,
                        Type = x.Type,
                        RoadClock = x.RoadClock,
                        YearOfProduce = x.YearOfProduce,
                        CarType = x.CarType,
                    });

                }
            }
            foreach (var car in k)
            {
                Console.WriteLine($"Auto:{car.Name},Przebieg:{car.RoadClock},Cena:{car.Type},href: {car.Href}\n");
            }
            var json = JsonConvert.SerializeObject(r);
            File.WriteAllText(@"D:\OtoMoto.json", json);
        }
    }
}