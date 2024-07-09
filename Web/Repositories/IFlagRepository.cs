using MongoDB.Bson;

namespace Flagger.Repositories
{
    interface IFlagRepository
    {
        Task<IEnumerable<ObjectId>> GetAllIds();
        Task<byte[]> GetContentById(ObjectId id);
        Task<IDictionary<string, object>> GetMetadataById(ObjectId id);
    }
}
