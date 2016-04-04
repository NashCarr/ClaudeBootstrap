using CommonData.Enums;

namespace DataLayerCommon.Addresses
{
    public class StateProvince
    {
        public StateProvince()
        {
            Name = string.Empty;
            StateProvinceId = 0;
            Country = CountryEnums.Country.None;
            Abbreviation = string.Empty;
        }

        public string Name { get; set; }
        public CountryEnums.Country Country { get; set; }
        public string Abbreviation { get; set; }
        public short StateProvinceId { get; set; }
    }
}