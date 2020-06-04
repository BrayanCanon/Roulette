using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheRoulette
{
    [Serializable]
    public class Roulette
    {
        public int id { get; set; }
        public string state { get; set; }
        public List<Bet> bets { get; set; }

        public Roulette()
        {
            id = 0;
            state = "Active";
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

        public void theBets(Bet pBet)
        {
            if (state.Equals("Active"))
            {
                if (pBet.amount % 2 == 0)
                {
                    pBet.result = "Win";
                }
                else
                {
                    pBet.result = "Lose";
                }
                bets.Add(pBet);
            }
        }
    }
}