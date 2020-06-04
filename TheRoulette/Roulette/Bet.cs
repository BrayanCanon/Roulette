using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheRoulette
{
    [Serializable]
    public class Bet
    {
        public int bettor { get; set; }
        public int amount { get; set; }
        public string result { get; set; }
        public string color { get; set; }
        public int number { get; set; }
        public Bet()
        {
            this.bettor = -1;
            this.amount = 0;
            this.result = "";
            this.color = "";
            this.number = 0;
        }


    }
}