using OurResumeIR.Application.Services.Interfaces;

using ChatApp.Domain.Models;
using ChatApp.Domain.Enums;
using ChatApp.Application.Contract.Persistence;
using ChatApp.Application.Models.User;
using ChatApp.Application.Features.Interfaces;

namespace ChatApp.Application.Features.Services
{
    public class UserService(IUserRepository userRepository
   
        ,IAuthService authService
        )
        : IUserService
    {
        public async Task<bool> Logout()
        {
          
          return await authService.SignOutAsync();
        }

        public async Task<RegisterResult> RegisterUser(RegisterViewModel viewModel)
        {
            if (await userRepository.EmailIsExist(viewModel.Email))
            {
                return RegisterResult.DupplicateEmail;
            }

            if (viewModel.Password != viewModel.RePassword)
            {
                return RegisterResult.UnequalPassAndRePass;
            }


            var user = new User
            {
                Id=Guid.NewGuid().ToString(),
                Email = viewModel.Email,
                UserName = viewModel.Email,
                

            };

            var status = await userRepository.CreateUser(user, viewModel.Password);
            if (status != null)
            {

                await authService.PasswordSignInAsync(user, viewModel.Password, false, false);

            }

            return RegisterResult.Success;
        }




        public async Task<LoginResult> LoginUser(LoginViewModel viewModel)
        {
            var user = await userRepository.GetUserByEmail(viewModel.Email);

            if (user == null)
                return LoginResult.UserNotFound;

            var result =await authService.PasswordSignInAsync(user, viewModel.Password, viewModel.RememberMe, false);

            if (result)
            {
                return LoginResult.Success;
            }

            return LoginResult.InvalidPassword;
        }


   

    }
} 
