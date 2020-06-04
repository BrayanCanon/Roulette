using Microsoft.Extensions.Caching.Memory;
using ServiceStack.Redis;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web;
using System.Web.Configuration;
using System.Web.Http;
using System.Web.Mvc;

namespace TheRoulette.Controllers
{
    public class ValuesController : ApiController
    {
        private List<Roulette> roulettes = new List<Roulette>();

        // GET api/values
        public int createNewRoulette()
        {
            Roulette newRoulette = new Roulette();
            newRoulette.createRoulette(roulettes.Count + 1);
            newRoulette.id = roulettes.Count + 1;
            roulettes.Add(newRoulette);

            return newRoulette.id;
        }

        // GET api/values/5
        public string rouletteOpening(int id)
        {
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
        public IHttpActionResult createNewBet(int id, Models.Request.BetJSON bet)
        {
            Bet newBet = new Bet();
            newBet.bettor = id;
            newBet.amount = bet.amount;
            newBet.result = bet.result;
            newBet.color = bet.color;
            newBet.number = bet.number;

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
            return Ok();
        }

        public List<String> closeBetsByID(int id)
        {
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

        public List<String> roulettesState()
        {
            List<String> ruletteState = new List<String>();
            for (int i = 0; i<roulettes.Count; i++)
            {
                ruletteState.Add("Roulette "+i+": "+roulettes[i].state);
            }
            return ruletteState;
        }

    }
}
