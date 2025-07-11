using ChatApp.Domain.Models;
using Project.Application.Contracts.Persistence;

namespace ChatApp.Application.Contract.Persistence
{
    public interface IUserRepository : IGenericIdentityRepository<User>
    {
        Task<User> GetUserByEmail(string email);
        Task<bool> EmailIsExist(string email);
        Task<string> CreateUser(User user, string Password);
    }
}
