using Mapster;
using MapsterMapper;
using Newtonsoft.Json;
using System.Reflection;

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

            var config = TypeAdapterConfig.GlobalSettings;
            config.Scan(Assembly.GetExecutingAssembly());

            services.AddSingleton(config);
            services.AddScoped<IMapper, ServiceMapper>();
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder =>
                    {
                        builder
                            .AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .WithExposedHeaders("Content-Range");
                    });
            });
            return services;
        }
    }
}
