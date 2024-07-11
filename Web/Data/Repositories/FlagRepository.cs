using Flagger.Data.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;

namespace Flagger.Data.Repositories
{
    public class FlagRepository : IFlagRepository
    {
        private readonly GridFSBucket bucket;

        public FlagRepository(IMongoDatabase database)
        {
            bucket = new GridFSBucket(database);
        }

        public async Task<IEnumerable<string>> GetAllIds()
        {
            using var cursor = await bucket.FindAsync(Builders<GridFSFileInfo<ObjectId>>.Filter.Empty);

            return (await cursor.ToListAsync()).Select(x => x.Id.ToString());
        }

        public async Task<byte[]> GetContentById(string id)
        {
            using var stream = new MemoryStream();

            await bucket.DownloadToStreamAsync(ObjectId.Parse(id), stream);
            return stream.ToArray();
        }

        public async Task<IDictionary<string, object>> GetMetadataById(string id)
        {
            var filter = Builders<GridFSFileInfo<ObjectId>>.Filter.Eq(x => x.Id, ObjectId.Parse(id));
            using var cursor = await bucket.FindAsync(filter);

            var flag = (await cursor.ToListAsync()).FirstOrDefault();
            if (flag is null)
                return new Dictionary<string, object>();

            return flag.Metadata.ToDictionary();
        }
    }
}
