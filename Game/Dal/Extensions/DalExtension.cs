using Dal.Context;
using Dal.Repositorires.Abstract;
using Dal.Repositorires.Concreate;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Dal.Extensions
{
    public static class DalExtension
    {
        public static IServiceCollection LoadDalLayerExtension(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddDbContext<GameDbContext>(option =>
    option.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
            );
            return services;
        }
        //bu metod program.cs de belirtilmeli
    }
}
