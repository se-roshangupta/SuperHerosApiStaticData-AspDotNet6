using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SuperHerosApiStaticData.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHerosController : ControllerBase
    {
        //To Access heros list from every where
        private static List<SuperHeros> heros = new List<SuperHeros>
            {
                new SuperHeros {Id=1, Name="Captain America", FirstName="Chris", LastName="Evans", Place="New York City"},
                new SuperHeros {Id=2, Name="Iron Man", FirstName="Robert", LastName="Downey Jr", Place="New York City"},
                new SuperHeros {Id=3, Name="Thor", FirstName="Chris", LastName="Hemsworth", Place="New York City"},
                new SuperHeros {Id=4, Name="Natasha Romanoff", FirstName="Scarlett", LastName="Johansson", Place="New york"}
            };

        //Get Hero List
        [HttpGet]
        //public async Task<IActionResult> Get()
        public async Task<ActionResult<List<SuperHeros>>> Get() //To show In Schemas
        {
            //To show heros list
            /*var heros = new List<SuperHeros>
            {
                new SuperHeros {Id=1, Name="Captain America", FirstName="Chris", LastName="Evans", Place="New York City"},
                new SuperHeros {Id=2, Name="Iron Man", FirstName="Robert", LastName="Downey Jr", Place="New York City"},
                new SuperHeros {Id=3, Name="Thor", FirstName="Chris", LastName="Hemsworth", Place="New York City"}
            };*/
            return Ok(heros);
        }

        // Get Single Heros By Id
        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHeros>> Get(int id)
        {
            var hero = heros.Find(h => h.Id == id);
            if (hero == null)
            {
                return BadRequest("Hero Not Found!");
            }
            return Ok(hero);
        }

        // To Add New Heros
        [HttpPost]
        public async Task<ActionResult<List<SuperHeros>>> AddHeros(SuperHeros hero)
        {
            heros.Add(hero);
            return Ok(heros);
        }

        // To Update Heros
        [HttpPut]
        public async Task<ActionResult<List<SuperHeros>>> UpdateHeros(SuperHeros request)
        {
            var hero = heros.Find(h => h.Id == request.Id);
            if (hero == null)
            {
                return BadRequest("Hero Not Found!");
            }

            hero.Name = request.Name;
            hero.FirstName = request.FirstName;
            hero.LastName = request.LastName;
            hero.Place = request.Place;
            return Ok(heros);
        }

        // Delete Single Heros By Id
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHeros>>> DeleteHreo(int id)
        {
            var hero = heros.Find(h => h.Id == id);
            if (hero == null)
            {
                return BadRequest("Hero Not Found!");
            }
            heros.Remove(hero);
            return Ok(heros);
        }
    }
}
