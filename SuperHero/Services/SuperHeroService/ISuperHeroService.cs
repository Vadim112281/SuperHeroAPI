using SuperHero.Models;

namespace SuperHero.Services.SuperHeroService
{
    public interface ISuperHeroService
    {
        List<HeroSuper> GetAllHeroes();
        HeroSuper GetSingleHero(int id);
        bool AddHero(HeroSuper hero);
        bool UpdateHero(int id, HeroSuper request);
        bool DeleteHero(int id);
    }
}
