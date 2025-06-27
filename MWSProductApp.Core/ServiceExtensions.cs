using Microsoft.Extensions.DependencyInjection;
using MediatR;
using FluentValidation;
using System.Reflection;
using MWSProductApp.Contract.Data.Login;
using MWSProductApp.Infrastructure.Repositories.Login;

namespace MWSProductApp.Core
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddScoped<IUserRepository, UserRegisterRepo>();
            services.AddScoped<IUserCredentialsRepository, UserCredentialService>();


            return services; 
        }
    }
}
