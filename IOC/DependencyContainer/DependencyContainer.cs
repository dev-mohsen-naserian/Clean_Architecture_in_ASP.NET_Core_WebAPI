using Application.Services.Implementation;
using Application.Services.Interfaces;
using Data.Repositories;
using Domain.Contrators;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC.DependencyContainer;

public static class DependencyContainer
{
    public static void RegisterServices(this IServiceCollection services)
    {
        #region Repository
        services.AddScoped<IUserRepository, UserRepository>();
        #endregion
        #region Service
        services.AddScoped<IUserService, UserService>();
        #endregion
    }
}
