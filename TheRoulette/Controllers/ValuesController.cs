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

        private int currentRoulette = 0;

        // GET api/values
        public int Get()
        {

            Roulette newRoulette = new Roulette();
            newRoulette.createRoulette(roulettes.Count + 1);
            newRoulette.id = roulettes.Count + 1;
            roulettes.Add(newRoulette);

            return newRoulette.id;
        }

        // GET api/values/5
        public string Get(int id)
        {

            return "value";
        }

        // POST api/values
        public IHttpActionResult createBet(Models.Request.BetJSON bet)
        {

            Bet newBet = new Bet();
            newBet.bettor = bet.bettor;
            newBet.amount = bet.amount;
            newBet.result = bet.result;
            newBet.color = bet.color;
            newBet.number = bet.number;

            return Ok(newBet);
            
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
