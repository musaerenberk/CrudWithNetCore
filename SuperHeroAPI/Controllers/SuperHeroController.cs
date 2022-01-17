using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]   
    public class SuperHeroController : Controller
    {
        private static List<SuperHero> heroes = new List<SuperHero>
        {
                new SuperHero
                {
                    Id = 1,
                    Name ="Spiderman",
                    FirstName="Peter",
                    LastName="Parker",
                    Place="New York City"

                },
                new SuperHero
                {
                    Id = 2,
                    Name ="Ironman",
                    FirstName="Tony",
                    LastName="Stark",
                    Place="Long Island"

                }
            };
        [HttpGet]  
        public async Task<ActionResult<List<SuperHero>>> Get()
        {

           return Ok(heroes);
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> Get(int id)
        {
            var hero = heroes.Find(h => h.Id == id);
            if (hero == null)
                return BadRequest("Hero not found");
            else
            return Ok(heroes);
        }
        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            heroes.Add(hero);
            return Ok(heroes);
        }
        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero request)
        {
            var hero = heroes.Find(h => h.Id == request.Id);
            if (hero == null)
                return BadRequest("Hero not found");

            hero.Name = request.Name;
            hero.FirstName = request.FirstName;
            hero.LastName = request.LastName;
            hero.Place = request.Place;

            return Ok(heroes);
        }
        [HttpDelete]
        public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
        {
            var hero = heroes.Find(h => h.Id == id);
            if (hero == null)
                return BadRequest("Hero not found");
            else
                heroes.Remove(hero);
                return Ok(heroes);
        }
    }
}
