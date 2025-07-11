using ChatApp.Application.Models.User;
using ChatApp.Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using OurResumeIR.Application.Services.Interfaces;


namespace OurResumeIR.MVC.Controllers
{
    public class AccountController (IUserService _userService): Controller
    {


        [HttpGet]
        public IActionResult Register()=>View();


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel register)
        {
            if (!ModelState.IsValid)
            {
                return View(register);
            }

            var result = await _userService.RegisterUser(register);

            switch (result)
            {
                case RegisterResult.Success:
                    ViewBag.Message = "ثبت نام شما با موفقیت انجام شد";
                    return RedirectToAction("Index", "Home");
                case RegisterResult.DupplicateEmail:
                    ViewBag.Message = "ایمیل وارد شده قبلا ثبت نام کرده است";
                    return View(register);
                case RegisterResult.UnequalPassAndRePass:
                    ViewBag.Message = "رمز و تکرار رمز برابر نیستند";
                    return View(register);
                default:
                    break;
            }

            return View(register);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost,ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result = await _userService.LoginUser(model);

            switch (result)
            {
                case LoginResult.Success:
                    return RedirectToAction("Index", "Home");

                case LoginResult.UserNotFound:
                    ModelState.AddModelError("", "کاربری با این ایمیل یافت نشد.");
                    break;

                case LoginResult.InvalidPassword:
                    ModelState.AddModelError("", "رمز عبور اشتباه است.");
                    break;
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _userService.Logout();
            return RedirectToAction(nameof(Login));
        }


        public IActionResult ForgotPassword() => View(); 
    }
}
