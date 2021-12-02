using OrderCollectorAPI.Models;

namespace OrderCollectorAPI.Services
{
    public interface IUserService
    {
        public Task<string> Login(Login login);

        public string GetUserEmail();

        public Task<User> GetCurrentUser();

        public Task<bool> CreateNewUser(Login login);

    }
}
