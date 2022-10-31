using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebScrappingOTOMOTO
{
    public class CarParams
    {
        public CarParams(string name,string href)
        {
            Name = name;
            Href = href;
        }
        public string Name { get; set; }
        public string Href { get; set; }
    }
}
