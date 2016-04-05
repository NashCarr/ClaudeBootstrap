using DataLayerCommon.BaseModels;
using static CommonData.Enums.CountryEnums;

namespace DataLayerCommon.Addresses
{
    public abstract class PostalCode : ModelBase
    {
        protected PostalCode()
        {
            PostalCodeId = 0;
            StateProvinceId = 0;
            City = string.Empty;
            ZipCode = string.Empty;
            Country = Country.UnitedStates;
            PostalCoordinates = new Coordinates();
        }

        public string City { get; set; }
        public string ZipCode { get; set; }
        public Country Country { get; set; }
        public int PostalCodeId { get; set; }
        public int StateProvinceId { get; set; }
        public Coordinates PostalCoordinates { get; set; }
    }
}