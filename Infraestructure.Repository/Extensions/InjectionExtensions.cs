using Infraestructure.Data;
using Infraestructure.Data.Contexts;
using Infraestructure.Interface.Connection;
using Infraestructure.Interface.Helpers;
using Infraestructure.Interface.Patterns;
using Infraestructure.Repository.Helpers;
using Infraestructure.Repository.Patterns;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infraestructure.Repository.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionInfraestructure(this IServiceCollection services, IConfiguration configuration)
        {
            var assembly = typeof(ProdContext).Assembly.FullName;

            services.AddSingleton<IConnectionFactory, ConnectionFactory>();
            services.AddDbContext<ProdContext>(opts => opts.UseSqlServer(configuration.GetConnectionString("ConexionProd"), b => b.MigrationsAssembly("Service.ApiController")));

            services.AddTransient<IUnitOfWork,UnitOfWork>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            return services;
        }
    }
}