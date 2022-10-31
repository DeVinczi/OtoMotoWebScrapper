using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebScrappingOTOMOTO
{
    public class CarDetails
    {
        public CarDetails(string type, string money,int roadClock,string yearOfProduce,string carType)
        {
            Type = type;
            Money = money;
            RoadClock = roadClock;
            YearOfProduce = yearOfProduce;
            CarType = carType;
        }

        public string Type { get; set; }
        public int RoadClock { get; set; }
        public string YearOfProduce { get; set; }
        public string CarType { get; set; }
        public string Money { get; set; }
    }
}
