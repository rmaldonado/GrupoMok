using Domain.Core.ValidationsAplications.User;
using Domain.Interface;
using Domain.Interface.ValidationInterface.User;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Domain.Core.Extensions
{
    public static class InjectionExtensions {
        public static IServiceCollection AddInjectionDomainCore(this IServiceCollection services, IConfiguration configuration) {
            services.AddSingleton(configuration);

            services.AddScoped<IMessageDomain, MessageDomain>();

            //services.AddScoped<ITokenValidationDomain, TokenValidationDomain>();

            services.AddScoped<ICompanysValidationsAplications, CompanysValidationsAplications>();
            services.AddScoped<IEditCompanysValidationsAplications, EditCompanysValidationsAplications>();
            services.AddScoped<IEditUserValidationApications, EditUserValidationApications>();
            services.AddScoped<ILoginvalidationAplications, LoginvalidationAplications>();
            services.AddScoped<IEditUserValidationApications, EditUserValidationApications>();
            services.AddScoped<IUserValidationInterface, UserValidationApications>();
            services.AddScoped<ITokenGenerateSegurityDomain, TokenGenerateSegurityDomain>();

            return services;
        }
    }
}
