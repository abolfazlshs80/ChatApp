using Microsoft.AspNetCore.Authentication.Cookies;

namespace ChatApp.Web.Tools.ExtensionMethod
{
    public static class InjectService
    {
   
        public static IServiceCollection AddMyAuthentication(this IServiceCollection services)
        {
            services.AddAuthentication(option =>
                {
                    option.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                })
                .AddCookie(Options =>
                {
                    Options.LoginPath = "/Account/login";
                });
            return services;
        }

    }
}
