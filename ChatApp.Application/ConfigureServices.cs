using System.Reflection;
using ChatApp.Application.Features.Interfaces;
using ChatApp.Application.Features.Services;
using Microsoft.Extensions.DependencyInjection;
using OurResumeIR.Application.Services.Interfaces;

namespace ChatApp.Application
{
 

   


    public static class ApplicationServiceRegistration
    {
        
        public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
        {
            #region Service
            //services.AddScoped<IFileUploaderService, LocalUploaderService>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IChatMessageService, ChatMessageService>();
            services.AddScoped<IChatRoomService, ChatRoomService>();


            #endregion


            return services;
         
        }
    }
}


    


        
   


