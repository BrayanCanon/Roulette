using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheRoulette.Models.Request
{
    public class BetJSON
    {
        public int bettor { get; set; }
        public int amount { get; set; }
        public string result { get; set; }
        public string color { get; set; }
        public int number { get; set; }
    }
}