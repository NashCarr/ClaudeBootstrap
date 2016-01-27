namespace ClaudeData.Models.Addresses
{
    public class PostalZone
    {
        public PostalZone()
        {
            Distance = 0;
            FacilityId = 1;
            PostalZoneId = 0;
        }

        public int PostalZoneId { get; set; }
        public int FacilityId { get; set; }
        public int Distance { get; set; }
    }
}