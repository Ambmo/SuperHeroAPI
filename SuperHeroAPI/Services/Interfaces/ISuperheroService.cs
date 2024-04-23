using SuperHeroAPI.Models;

namespace SuperheroAPI.Services.Interfaces
{
    public interface ISuperheroService
    {
        Task<string> GetSuperheroById(int id);

        //Task<IEnumerable<Superhero>> SearchSuperheroes(string Name);
    }
}
