using ChatApp.Domain.Enums;
using LoginViewModel = ChatApp.Application.Models.User.LoginViewModel;
using RegisterViewModel = ChatApp.Application.Models.User.RegisterViewModel;

namespace OurResumeIR.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<LoginResult> LoginUser(LoginViewModel model);
        Task<bool> Logout();
        Task<RegisterResult> RegisterUser(RegisterViewModel viewModel);


    }
}
