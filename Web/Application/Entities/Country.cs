using CountryModel = Flagger.Data.Models.Country;

namespace Flagger.Application.Entities
{
    public class Country
    {
        public string Id { get; private set; }
        public string Name { get; private set; }
        public string Abbreviation { get; private set; }
        public string LandArea { get; private set; }
        public string AgriculturalLand { get; private set; }
        public string ArmedForcesSize { get; private set; }
        public string BirthRate { get; private set; }
        public string Capital { get; private set; }
        public string Co2Emissions { get; private set; }
        public string CurrencyCode { get; private set; }
        public string FertilityRate { get; private set; }
        public string ForestedArea { get; private set; }
        public string GasolinePrice { get; private set; }
        public string GDP { get; private set; }
        public string InfantMortality { get; private set; }
        public string LargestCity { get; private set; }
        public string LifeExpectancy { get; private set; }

        public Country FromModel(CountryModel model)
        {
            Id = model.Id.ToString();
            Name = model.Name;
            Abbreviation = model.Abbreviation;
            LandArea = model.LandArea;
            AgriculturalLand = model.AgriculturalLand;
            ArmedForcesSize = model.ArmedForcesSize;
            BirthRate = model.BirthRate;
            Capital = model.Capital;
            Co2Emissions = model.Co2Emissions;
            CurrencyCode = model.CurrencyCode;
            FertilityRate = model.FertilityRate;
            ForestedArea = model.ForestedArea;
            GasolinePrice = model.GasolinePrice;
            GDP = model.GDP;
            InfantMortality = model.InfantMortality;
            LargestCity = model.LargestCity;
            LifeExpectancy = model.LifeExpectancy;

            return this;
        }
    }
}
