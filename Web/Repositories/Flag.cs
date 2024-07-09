using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Flagger.Repositories
{
    public class Flag
    {
        public ObjectId Id { get; set; }
    }
}
