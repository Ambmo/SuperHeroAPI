using SuperheroAPI.DAL;
using SuperheroAPI.Models;
using SuperheroAPI.Services.Interfaces;

public class UserService : IUserService
{
    private readonly IRepository<User> _userRepository;

    public UserService(IRepository<User> userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> CreateUser(string username)
    {
        var newUser = new User
        {
            Username = username,
            UserId = GenerateRandomUserId() // Assuming this method generates a unique user ID
        };

        await _userRepository.Add(newUser);
        return newUser;
    }

    public async Task<User?> GetUserById(string userId)
    {
        var users = await _userRepository.Find(u => u.UserId == userId);
        return users.FirstOrDefault();
    }

    //for future changes
    private string GenerateRandomUserId()
    {
        return Guid.NewGuid().ToString();
    }
}
