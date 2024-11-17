using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace GlobalE.BL
{
    public static class Startup
    {
        public static void AddGlobaleBl(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<TimerService>();
            services.AddHostedService<TimerHostedService>();
            services.AddHttpClient(nameof(TimerHostedService));


            var repositoryConfigurations = new Dictionary<string, Action>
            {
                { "Mongo", () => ConfigureMongoServices(services,configuration ) },
                { "Mssql",  () => ConfigureMssqlServices(services,configuration ) },
                { "InMemory", () => services.AddSingleton<ITimerRepository, InMemoryTimerRepository>() }
            };

            // Retrieve the repository type from configuration
            var repositoryType = configuration["RepositorySettings:RepositoryType"];

            // Check if the repository type is valid and configure it
            if (repositoryConfigurations.TryGetValue(repositoryType, out var configureAction))
            {
                configureAction();
            }
            else
            {
                throw new Exception("Invalid repository type configured.");
            }
        }


        private static void ConfigureMongoServices(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MongoSettings>(configuration.GetSection("MongoSettings"));
            services.AddSingleton<IMongoClient>(sp =>
            {
                var settings = sp.GetRequiredService<IOptions<MongoSettings>>().Value;
                return new MongoClient(settings.ConnectionString);
            });
            services.AddSingleton(sp =>
            {
                var settings = sp.GetRequiredService<IOptions<MongoSettings>>().Value;
                var client = sp.GetRequiredService<IMongoClient>();
                return client.GetDatabase(settings.DatabaseName);
            });
            services.AddSingleton<ITimerRepository, MongoTimerRepository>();
        }

        private static void ConfigureMssqlServices(IServiceCollection services, IConfiguration configuration)
        {
            throw new NotImplementedException();
            //services.Configure<MssqlSettings>(Configuration.GetSection("MssqlSettings"));
            //// For example, if using Entity Framework:
            //// services.AddDbContext<MyDbContext>(options =>
            ////     options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            //services.AddSingleton<ITimerRepository, MssqlTimerRepository>();
        }

    }
}