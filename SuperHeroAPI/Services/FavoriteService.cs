using SuperheroAPI.DAL;
using SuperheroAPI.Services.Interfaces;
using SuperHeroAPI.Models;
using System.Linq;
using System.Linq.Expressions;

namespace SuperheroAPI.Services
{
    public class FavoriteService : IFavoriteService
    {
        private readonly IRepository<Favorite> _favoriteRepository;

        public FavoriteService(IRepository<Favorite> favoriteRepository)
        {
            _favoriteRepository = favoriteRepository;
        }

        public async Task AddFavorite(Favorite favorite)
        {
            await _favoriteRepository.Add(favorite);
        }

        public async Task<IEnumerable<Favorite>> GetFavorites()
        {
            return await _favoriteRepository.GetAll();
        }

        public async Task<IEnumerable<Favorite>> GetFavoritesByUserId(string userId)
        {
            return await _favoriteRepository.Find(f => f.UserId == userId);
        }

        //for future use "search favs"
        public async Task<IEnumerable<Favorite>> FindFavorites(Expression<Func<Favorite, bool>> predicate)
        {
            return await _favoriteRepository.Find(predicate);
        }
    }

}


