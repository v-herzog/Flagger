using Flagger.Data.Configuration.Options;
using Flagger.Data.Interfaces;
using Flagger.Data.Repositories;
using MongoDB.Driver;

namespace Flagger.Data.Configuration
{
    public static class MongoConfiguration
    {
        public static void ConfigureMongoDB(this IServiceCollection services)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var options = configuration.GetSection("MongoDB").Get<MongoOptions>();

            services.AddSingleton(provider =>
            {
                var client = new MongoClient(options.ConnectionString);
                return client.GetDatabase(options.DatabaseName);
            });

            services.AddSingleton<IFlagRepository, FlagRepository>();
            services.AddSingleton<ICountryRepository, CountryRepository>();
        }
    }
}
