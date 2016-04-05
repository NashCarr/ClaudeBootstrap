using CommonData.Enums;
using static CommonData.Enums.PlaceEnums;
using static CommonData.Enums.TimeZoneEnums;

namespace CommonDataRetrieval.Places
{
    public class PlaceList
    {
        public PlaceList()
        {
            PlaceId = 0;
            DisplayOrder = 0;
            Name = string.Empty;
            Country = CountryEnums.Country.None;
            Division = string.Empty;
            Department = string.Empty;
            CountryName = string.Empty;
            PlaceType = PlaceType.None;
            DisplaySort = string.Empty;
            TimeZone = ClaudeTimeZone.None;
        }

        public int PlaceId { get; set; }
        public string Name { get; set; }
        public CountryEnums.Country Country { get; set; }
        public string Division { get; set; }
        public string Department { get; set; }
        public string CountryName { get; set; }
        public string DisplaySort { get; set; }
        public short DisplayOrder { get; set; }
        public string TimeZoneName { get; set; }
        public PlaceType PlaceType { get; set; }
        public ClaudeTimeZone TimeZone { get; set; }
    }
}