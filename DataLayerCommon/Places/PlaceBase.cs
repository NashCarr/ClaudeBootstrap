using DataLayerCommon.BaseModels;
using static CommonData.Enums.CountryEnums;
using static CommonData.Enums.PlaceEnums;
using static CommonData.Enums.TimeZoneEnums;

namespace DataLayerCommon.Places
{
    public class PlaceBase : AdminBase
    {
        public PlaceBase()
        {
            PlaceId = 0;
            Division = string.Empty;
            Department = string.Empty;
            PlaceType = PlaceType.None;
            Country = Country.None;
            TimeZone = ClaudeTimeZone.None;
        }

        public int PlaceId { get; set; }
        public Country Country { get; set; }
        public string Division { get; set; }
        public string Department { get; set; }
        public PlaceType PlaceType { get; set; }
        public ClaudeTimeZone TimeZone { get; set; }
    }
}