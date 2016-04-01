using CommonData.Enums;
using DataManagement.BaseModels;

namespace DataManagement.Models.Places
{
    public class Place : AdminBase
    {
        public Place()
        {
            PlaceId = 0;
            Division = string.Empty;
            Department = string.Empty;
            PlaceType = PlaceEnums.PlaceType.None;
            Country = CountryEnums.Country.None;
            TimeZone = TimeZoneEnums.ClaudeTimeZone.None;
        }

        public int PlaceId { get; set; }
        public CountryEnums.Country Country { get; set; }
        public string Division { get; set; }
        public string Department { get; set; }
        public PlaceEnums.PlaceType PlaceType { get; set; }
        public TimeZoneEnums.ClaudeTimeZone TimeZone { get; set; }
    }
}