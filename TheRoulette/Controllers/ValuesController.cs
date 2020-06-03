using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TheRoulette;

namespace TheRoulette.Controllers
{
    public class ValuesController : ApiController
    {
        private List<Roulette> roulettes = new List<Roulette>();

        public void iniciarRuleta()
        {
            for (int i = 0; i < 10; i++)
            {
                Roulette newRoulette = new Roulette();
                newRoulette.id = i;
                newRoulette.state = "Active";

                Bet myBet = new Bet();
                myBet.amount = 1000;
                myBet.bettor = i;
                myBet.number = 6;
                myBet.result = "Win";

                Bet myBet2 = new Bet();
                myBet2.amount = 2000;
                myBet2.bettor = i + 1;
                myBet2.number = 16;
                myBet2.result = "Lose";

                newRoulette.bets.Add(myBet);
                newRoulette.bets.Add(myBet2);
                roulettes.Add(newRoulette);
            }
        }

        // GET api/values
        public int createNewRoulette()
        {
            iniciarRuleta();
            Roulette newRoulette = new Roulette();
            newRoulette.createRoulette(roulettes.Count + 1);
            newRoulette.id = roulettes.Count + 1;
            roulettes.Add(newRoulette);

            return newRoulette.id;
        }

        

        // GET api/values/5
        public string rouletteOpening(int id)
        {
            iniciarRuleta();
            Roulette currentRoulette = null;
            string result = "Denied";
            foreach (Roulette r in roulettes)
            {
                if (r.id == id)
                {
                    currentRoulette = r;
                    currentRoulette.opening();
                    result = "Success!";
                }
            }
            return result;
        }


        // PUT api/values/5
        public IHttpActionResult createTheBet(int id, Models.Request.BetJSON bet)
        {
            Bet newBet = new Bet();
            newBet.bettor = id;
            newBet.amount = bet.amount;
            newBet.result = bet.result;
            newBet.color = bet.color;
            newBet.number = bet.number;

            iniciarRuleta();

            foreach (Roulette r in roulettes)
            {
                if (newBet.amount <= 10000 && newBet.amount > 0 && newBet.number <= 36 && newBet.number > 0)
                {
                    if (r.state.Equals("Active"))
                    {
                        r.theBets(newBet);
                        break;
                    }
                }
            }
            return Ok(roulettes[0]);
        }


        public List<String> closeBet(int id)
        {
            iniciarRuleta();
            List<String> results = new List<String>();
            foreach (Roulette r in roulettes)
            {
                if (r.id == id)
                {
                    foreach(Bet b in r.bets)
                    {
                        results.Add(b.result);
                    }
                }
            }
            return results;
        }

        public List<String> getRoulettesState()
        {
            List<String> ruletteState = new List<String>();
            iniciarRuleta();
            for (int i = 0; i<roulettes.Count; i++)
            {
                ruletteState.Add("Roulette "+i+": "+roulettes[i].state);
            }
            return ruletteState;
        }

    }
}
