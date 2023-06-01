using Application.Interface;
using Domain.Interface.ValidationInterface.User;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Transversal.Common.Helpers;

namespace Application.Main.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionAplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(configuration);
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<IUserApplication, UserApplication>();
            services.AddScoped<IUserValidationInterface, UserValidationApications>();
            services.AddScoped<IRolesApplication, RolesApplication>();
            services.AddScoped<IMenuValidationAplications, MenuValidationAplications>();
            services.AddScoped<IEditMenuValidationAplications, EditMenuValidationAplications>();
            services.AddScoped<IHelpful, Helpful>();

            return services;
        }
    }
}
