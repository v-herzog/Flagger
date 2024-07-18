using Flagger.Application.Entities;

namespace Flagger.Application.Interfaces
{
    public interface IGameService
    {
        Task<Game> Create();
        Game Get();
        Task<IDictionary<string, string>> GetCountryNames();
        Task SetupFlag();
        Task<bool> Validate(string countryId);
    }
}
