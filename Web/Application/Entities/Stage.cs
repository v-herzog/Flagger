namespace Flagger.Application.Entities
{
    public class Stage
    {
        public Country Country { get; private set; }
        public Flag Flag { get; private set; }

        public void SetCountry(Country country) => Country = country;
        public void SetFlag(Flag flag) => Flag = flag;
    }
}
