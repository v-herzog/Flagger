using MongoDB.Bson;

namespace Flagger.Repositories
{
    interface ICountryRepository
    {
        Task<IDictionary<string, string>> GetAllNames();
        Task<Country> GetById(ObjectId id);
    }
}
