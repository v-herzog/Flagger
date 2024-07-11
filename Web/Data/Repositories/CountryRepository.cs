using Flagger.Data.Interfaces;
using Flagger.Data.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Flagger.Data.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly IMongoCollection<Country> collection;

        public CountryRepository(IMongoDatabase database)
        {
            collection = database.GetCollection<Country>("Countries");
        }

        public async Task<IDictionary<string, string>> GetAllNames()
        {
            return (await collection.FindAsync(_ => true))
                .ToList()
                .ToDictionary(x => x.Id.ToString(), x => x.Name);
        }

        public async Task<Country> GetById(string id)
        {
            var filter = Builders<Country>.Filter.Eq(x => x.Id, ObjectId.Parse(id));
            return await collection.Find(filter).FirstOrDefaultAsync();
        }
    }
}
