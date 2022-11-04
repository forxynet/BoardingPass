using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Models
{
    public class BoardingPass
    {
        public string NameOfPassenger { get; set; }        
        public string Carrier { get; set; }
        public string FlightNo { get; set; }
        public string Class { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Date { get; set; }        
        public string Luggage { get; set; }
        public string Seat { get; set; }
        public string Gate { get; set; }
        public string BoardingTime { get; set; }
    }
}
