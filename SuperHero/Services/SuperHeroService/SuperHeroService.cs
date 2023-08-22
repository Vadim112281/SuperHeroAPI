using Microsoft.AspNetCore.Http.HttpResults;
using SuperHero.Data;
using SuperHero.Models;

namespace SuperHero.Services.SuperHeroService
{
    public class SuperHeroService : ISuperHeroService
    {
        private readonly AppDbContext _context;

        public SuperHeroService(AppDbContext context)
        {
            _context = context;
        }

        public bool AddHero(HeroSuper hero)
        {
            if(hero != null)
            {
                _context.SuperHeroes.Add(hero);
                _context.SaveChanges();

                return true;
            }

            return false;
        }

        public bool DeleteHero(int id)
        {
            var hero = _context.SuperHeroes.FirstOrDefault(x => x.Id == id);

            if(hero != null)
            {
                _context.SuperHeroes.Remove(hero);
                _context.SaveChanges();

                return true;
            }

            return false;
        }

        public List<HeroSuper> GetAllHeroes()
        {
            return _context.SuperHeroes.ToList();
        }

        public HeroSuper GetSingleHero(int id)
        {

            var hero = _context.SuperHeroes.FirstOrDefault(x => x.Id == id);

            return hero;

        }

        public bool UpdateHero(int id, HeroSuper request)
        {
            var hero = _context.SuperHeroes.FirstOrDefault(x => x.Id == id);

            if(hero != null)
            {
                hero.FirstName = request.FirstName;
                hero.LastName = request.LastName;
                hero.Name = request.Name;
                hero.Place= request.Place;

                _context.SaveChanges();

                return true;
            }

            return false;
        }
    }
}
