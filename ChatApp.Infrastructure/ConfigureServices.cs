using ChatApp.Application.Contract.Persistence;
using ChatApp.Application.Features.Interfaces;
using ChatApp.Domain.Models;
using ChatApp.Infrastructure.Context;
using ChatApp.Infrastructure.Repositories;
using ChatApp.Infrastructure.Repositories.Basse;
using ChatApp.Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Project.Application.Contracts.Persistence;
using Project.Persistence.Repositories;

namespace ChatApp.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection RegisterInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        #region AppSetting Bind

        //services.Configure<PainginagtionViewModel>(options =>
        //    configuration.GetSection("Painginagtion").Bind(options));

        #endregion


        #region DbContext
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("LocalMain")));
        #endregion


        #region Repository
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IChatRoomRepository, ChatRoomRepository>();
        services.AddScoped<IChatMessageRepository, ChatMessageRepository>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        #endregion



        #region Identity

        services.AddIdentity<User, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

        #endregion

        #region Service

        services.AddScoped<IAuthService, AuthService>();

        #endregion


        return services;
    }

}
