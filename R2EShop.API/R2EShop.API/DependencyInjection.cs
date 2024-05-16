using Newtonsoft.Json;

namespace R2EShop.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            // Add services to the container.
            services.AddControllers()
                 .AddNewtonsoftJson(
                      options => { options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore; }
                  );

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            return services;
        }
    }
}
