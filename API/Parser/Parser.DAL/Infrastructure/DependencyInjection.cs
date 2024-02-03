using Microsoft.Extensions.DependencyInjection;
using Parser.DAL.Context;
using Parser.DAL.Interfaces.Uow;
using Parser.DAL.Repositories.Uow;

namespace Parser.DAL.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDalServiceCollection(this IServiceCollection services, string configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
