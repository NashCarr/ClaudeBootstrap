using static CommonData.Enums.CountryEnums;
using static CommonData.Enums.PlaceEnums;
using static CommonData.Enums.TimeZoneEnums;

namespace CommonDataRetrieval.Facility
{
    public class FacilityList
    {
        public FacilityList()
        {
            Radius = 0;
            PlaceId = 0;
            DisplayOrder = 0;
            PrimaryPhone = 0;
            Name = string.Empty;
            City = string.Empty;
            ZipCode = string.Empty;
            Address = string.Empty;
            Country = Country.None;
            Division = string.Empty;
            Department = string.Empty;
            CountryName = string.Empty;
            PlaceType = PlaceType.None;
            DisplaySort = string.Empty;
            StateProvince = string.Empty;
            TimeZone = ClaudeTimeZone.None;
        }

        public int PlaceId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public short Radius { get; set; }
        public string ZipCode { get; set; }
        public string Address { get; set; }
        public Country Country { get; set; }
        public string Division { get; set; }
        public string Department { get; set; }
        public long PrimaryPhone { get; set; }
        public string CountryName { get; set; }
        public string DisplaySort { get; set; }
        public short DisplayOrder { get; set; }
        public string TimeZoneName { get; set; }
        public PlaceType PlaceType { get; set; }
        public string StateProvince { get; set; }
        public ClaudeTimeZone TimeZone { get; set; }
    }
}