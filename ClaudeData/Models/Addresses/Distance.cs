namespace DataManagement.Models.Addresses
{
    public class Distance
    {
        public Distance()
        {
            Miles = 0;
            FacilityId = 1;
            DistanceId = 0;
            DistanceType = 0;
            PostalZoneId = 0;
        }

        public int Miles { get; set; }
        public int DistanceId { get; set; }
        public int FacilityId { get; set; }
        public int PostalZoneId { get; set; }
        public short DistanceType { get; set; }
    }
}