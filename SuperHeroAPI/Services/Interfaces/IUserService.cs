using SuperheroAPI.Models;

namespace SuperheroAPI.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> CreateUser(string username);
        Task<User?> GetUserById(string userId);
    }
}
