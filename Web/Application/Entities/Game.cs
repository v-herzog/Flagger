namespace Flagger.Application.Entities
{
    public class Game
    {
        private static Dictionary<GameStateEnum, List<GameStateEnum>> allowedStateChanges = new ()
        {
            { GameStateEnum.START, new List<GameStateEnum> { GameStateEnum.GUESS } },
            { GameStateEnum.GUESS, new List<GameStateEnum> { GameStateEnum.DETAILS, GameStateEnum.FINISH } },
            { GameStateEnum.DETAILS, new List<GameStateEnum> { GameStateEnum.GUESS } },
            { GameStateEnum.FINISH, new List<GameStateEnum> { GameStateEnum.GUESS } }
        };

        public GameStateEnum State { get; private set; }
        public IList<string> FlagDeck { get; private set; }
        public Stage CurrentStage { get; private set; }
        public IList<string> CorrectGuesses { get; private set; }
        public int Score { get => CorrectGuesses.Count; }

        public Game()
        {
            State = GameStateEnum.START;
            CurrentStage = new Stage();
            CorrectGuesses = [];
        }

        public void SetFlagDeck(IList<string> flags)
        {
            FlagDeck = flags;
            CorrectGuesses = [];
        }

        public void Next(GameStateEnum nextState, Country? country = null, Flag? flag = null)
        {
            UpdateState(nextState);
            UpdateFlag(flag);
            UpdateCountry(country);
            UpdateCorrectGuesses(nextState, country);
        }

        private void UpdateFlag(Flag flag)
        {
            if (flag is null)
                return;

            if (CurrentStage?.Flag is not null)
                FlagDeck.Remove(CurrentStage.Flag.Id);

            CurrentStage.SetFlag(flag);
        }

        private void UpdateCountry(Country country)
        {
            if (country is null)
                return;

            CurrentStage.SetCountry(country);
        }

        private void UpdateState(GameStateEnum nextState)
        {
            if (allowedStateChanges[State].Contains(nextState))
                State = nextState;
        }

        private void UpdateCorrectGuesses(GameStateEnum nextState, Country country)
        {
            if (country is null)
                return;

            if (nextState is GameStateEnum.DETAILS)
                CorrectGuesses.Add(CurrentStage.Country.Name);
        }
    }
}
