using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Flagger.Repositories
{
    [BsonIgnoreExtraElements]
    public class Country
    {
        public ObjectId Id { get; set; }
        [BsonElement("Country")]
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        [BsonElement("Land Area(Km2)")]
        public string LandArea { get; set; }
        [BsonElement("Agricultural Land( %)")]
        public string AgriculturalLand { get; set; }
        public string ArmedForcesSize { get; set; }
        public string BirthRate { get; set; }
        [BsonElement("Capital/Major City")]
        public string Capital { get; set; }
        [BsonElement("Co2-Emissions")]
        public string Co2Emissions { get; set; }
        [BsonElement("Currency-Code")]
        public string CurrencyCode { get; set; }
        [BsonElement("Fertility Rate")]
        public string FertilityRate { get; set; }
        [BsonElement("Forested Area(%)")]
        public string ForestedArea { get; set; }
        [BsonElement("Gasoline Price")]
        public string GasolinePrice { get; set; }
        public string GDP { get; set; }
        [BsonElement("Infant mortality")]
        public string InfantMortality { get; set; }
        [BsonElement("Largest city")]
        public string LargestCity { get; set; }
        [BsonElement("Life expectancy")]
        public string LifeExpectancy { get; set; }
    }
}
