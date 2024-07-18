using Flagger.Application.Entities;
using Flagger.Application.Extensions;
using Flagger.Application.Interfaces;
using Flagger.Data.Interfaces;

namespace Flagger.Application.Services
{
    public class GameService : IGameService
    {
        private readonly IFlagRepository flagRepository;
        private readonly ICountryRepository countryRepository;
        private readonly Game runningGame;

        public GameService(IFlagRepository flagRepository, ICountryRepository countryRepository)
        {
            this.flagRepository = flagRepository;
            this.countryRepository = countryRepository;
            this.runningGame = new Game();
        }

        public async Task<Game> Create()
        {
            var result = await flagRepository.GetAllIds();
            var ids = result.Shuffle()
                .Select(x => x.ToString())
                .ToList();

            runningGame.SetFlagDeck(ids);
            runningGame.Next(GameStateEnum.GUESS);

            return runningGame;
        }

        public Game Get() => runningGame;
        
        public async Task<IDictionary<string, string>> GetCountryNames() => await countryRepository.GetAllNames();

        public async Task SetupFlag()
        {
            var id = runningGame.FlagDeck.First();
            var array = await flagRepository.GetContentById(id);
            
            runningGame.Next(GameStateEnum.GUESS, flag: new Flag(id, array));
        }

        public async Task<bool> Validate(string countryId)
        {
            var country = await GetCountryFromFlag();
            var result = countryId == country.Id.ToString();

            runningGame.Next(result ? GameStateEnum.DETAILS : GameStateEnum.FINISH, country);

            return result;
        }

        private async Task<Country> GetCountryFromFlag()
        {
            var flagId = runningGame.CurrentStage.Flag.Id;
            var metadata = await flagRepository.GetMetadataById(flagId);

            var flagCountryId = metadata["countryId"].ToString();
            var model = await countryRepository.GetById(flagCountryId);

            return new Country().FromModel(model);
        }
    }
}
