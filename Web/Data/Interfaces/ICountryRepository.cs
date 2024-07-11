using Flagger.Data.Models;
using MongoDB.Bson;

namespace Flagger.Data.Interfaces
{
    public interface ICountryRepository
    {
        Task<IDictionary<string, string>> GetAllNames();
        Task<Country> GetById(string id);
    }
}
