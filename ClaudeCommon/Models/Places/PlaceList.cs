using CommonData.Enums;

namespace CommonData.Models.Places
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
            PlaceType = PlaceEnums.PlaceType.None;
            DisplaySort = string.Empty;
            TimeZone = TimeZoneEnums.ClaudeTimeZone.None;
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
        public PlaceEnums.PlaceType PlaceType { get; set; }
        public TimeZoneEnums.ClaudeTimeZone TimeZone { get; set; }
    }
}