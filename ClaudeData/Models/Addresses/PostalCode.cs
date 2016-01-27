using ClaudeData.BaseModels;
using static ClaudeCommon.Enums.CountryEnums;

namespace ClaudeData.Models.Addresses
{
    public abstract class PostalCode : ModelBase
    {
        protected PostalCode()
        {
            PostalCodeId = 0;
            City = string.Empty;
            ZipCode = string.Empty;
            StateProvince = string.Empty;
            Country = Country.UnitedStates;
            PostalCoordinates = new Coordinates();
        }

        public string City { get; set; }
        public string ZipCode { get; set; }
        public Country Country { get; set; }
        public int PostalCodeId { get; set; }
        public string StateProvince { get; set; }
        public Coordinates PostalCoordinates { get; set; }
    }
}