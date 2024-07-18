using FlagModel = Flagger.Data.Models.Flag;

namespace Flagger.Application.Entities
{
    public class Flag
    {
        public string Id { get; private set; }
        public string Source { get; private set; }

        public Flag (string id, byte[]? array = null)
        {
            Id = id;
            Source = Convert.ToBase64String(array);
        }
    }
}
