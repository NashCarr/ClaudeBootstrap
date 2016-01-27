using ClaudeData.BaseModels;
using static ClaudeCommon.Enums.PlaceEnums;
using static ClaudeCommon.Enums.TimeZoneEnums;

namespace ClaudeData.Models.Places
{
    public class Place : AdminBase
    {
        public Place()
        {
            PlaceId = 0;
            Division = string.Empty;
            Department = string.Empty;
            PlaceType = PlaceType.None;
            PlaceTypeName = string.Empty;
            TimeZone = ClaudeTimeZone.None;
        }

        public int PlaceId { get; set; }
        public string Division { get; set; }
        public string Department { get; set; }
        public PlaceType PlaceType { get; set; }
        public string PlaceTypeName { get; set; }
        public ClaudeTimeZone TimeZone { get; set; }
    }
}