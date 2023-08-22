using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHero.Models;
using SuperHero.Services.SuperHeroService;

namespace SuperHero.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly ISuperHeroService _service;

        public SuperHeroController(ISuperHeroService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<HeroSuper>>> GetAllHeroes()
        {
            var heroes = _service.GetAllHeroes();
            return Ok(heroes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingleHero(int id)
        {
            var hero = _service.GetSingleHero(id);

            if(hero == null)
            {
                return NotFound("Hero doesn`t exist"); 
            }

            return Ok(hero);
        }

        [HttpPost]
        public async Task<IActionResult> CreateHero([FromBody]HeroSuper request)
        {
            var hero = _service.AddHero(request);

            if(hero != null)
            {
                return Ok("Hero was created");
            }

            return BadRequest("Error with creating the hero!");  
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHero(int id, [FromBody] HeroSuper request)
        {
            var hero = _service.UpdateHero(id, request);

            if(hero != null)
            {
                return Ok("Hero was created");
            }

            return BadRequest("Eror with updating the hero");
            
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteHero(int id)
        {
            var hero = _service.DeleteHero(id);
            
            if(hero != null)
            {
                return Ok("Hero was deleted");
            }

            return BadRequest("Error with deleting the hero!");

            
        }
    } 
}
 