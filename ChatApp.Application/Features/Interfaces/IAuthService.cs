using ChatApp.Domain.Models;

namespace ChatApp.Application.Features.Interfaces
{
    public interface IAuthService
    {
        Task<bool> PasswordSignInAsync(User user,string password,bool RemeberMe,bool IsLock);
        Task<bool> SignOutAsync();
    }
}
