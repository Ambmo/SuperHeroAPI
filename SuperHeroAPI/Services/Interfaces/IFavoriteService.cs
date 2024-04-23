using SuperHeroAPI.Models;
using System.Linq.Expressions;

namespace SuperheroAPI.Services.Interfaces
{
    public interface IFavoriteService
    {
        public Task AddFavorite(Favorite favorite);
        public Task<IEnumerable<Favorite>> GetFavorites();
        Task<IEnumerable<Favorite>> GetFavoritesByUserId(string userId);
        //for future use "search favs"
        public Task<IEnumerable<Favorite>> FindFavorites(Expression<Func<Favorite, bool>> predicate);

    }
}
