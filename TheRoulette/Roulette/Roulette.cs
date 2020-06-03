using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheRoulette
{
    public class Roulette
    {
        public int id { get; set; }
        public string state { get; set; }
        List<Bet> bets { get; set; }

        public Roulette()
        {
            id = 0;
            state = "Inactive";
            bets = new List<Bet>();
        }


        public int createRoulette(int newId)
        {
            id = newId;
            return id;
        }
        public void opening()
        {
            state = "Active";
        }

        public void theBet(Bet pBet)
        {
            if (state.Equals("Active"))
            {
                Bet tnew = pBet;

                bets.Add(tnew);
            }
        }

    }
}