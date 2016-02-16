using static ClaudeCommon.Enums.PlaceEnums;
using static ClaudeCommon.Enums.TimeZoneEnums;

namespace ClaudeCommon.Models
{
    public class Place
    {
        public Place()
        {
            PlaceId = 0;
            DisplayOrder = 0;
            Name = string.Empty;
            Division = string.Empty;
            Department = string.Empty;
            PlaceType = PlaceType.None;
            TimeZone = ClaudeTimeZone.None;
        }
        public int PlaceId { get; set; }
        public string Name { get; set; }
        public string Division { get; set; }
        public string Department { get; set; }
        public short DisplayOrder { get; set; }
        public PlaceType PlaceType { get; set; }
        public ClaudeTimeZone TimeZone { get; set; }
    }
}