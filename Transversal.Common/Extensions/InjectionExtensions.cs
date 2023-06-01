using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TransversalCommon;
using TransversalCommon.Interfaces;

namespace Transversal.Common.Extensions {
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionCommon(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(configuration);

            services.AddScoped(typeof(IAppLogger), typeof(LoggerAdapter));

            services.AddScoped<IRestClient, RestClient>();
            
            return services;
        }
    }
}