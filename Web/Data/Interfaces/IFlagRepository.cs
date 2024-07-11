namespace Flagger.Data.Interfaces
{
    public interface IFlagRepository
    {
        Task<IEnumerable<string>> GetAllIds();
        Task<byte[]> GetContentById(string id);
        Task<IDictionary<string, object>> GetMetadataById(string id);
    }
}
