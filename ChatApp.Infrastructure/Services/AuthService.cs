using Microsoft.AspNetCore.Identity;
using ChatApp.Domain.Models;
using ChatApp.Application.Features.Interfaces;

namespace ChatApp.Infrastructure.Services
{
    public class AuthService(SignInManager<User> _signInManager) : IAuthService
    {

        public async Task<bool> PasswordSignInAsync(User user, string Password, bool RememberMe, bool IsLock)
        {
            await _signInManager.PasswordSignInAsync(user, Password, RememberMe, false);
            return true;
        }

        public async Task<bool> SignOutAsync()
        {
            await _signInManager.SignOutAsync();
            return true;

        }
    }
}
