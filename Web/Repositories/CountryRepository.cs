using MongoDB.Bson;
using MongoDB.Driver;

namespace Flagger.Repositories
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

        public async Task<Country> GetById(ObjectId id)
        {
            var filter = Builders<Country>.Filter.Eq(x => x.Id, id);
            return await collection.Find(filter).FirstOrDefaultAsync();
        }
    }
}
