namespace CommonDataSave.Facility
{
    public class FacilityResourceSave : SaveBase
    {
        public FacilityResourceSave()
        {
            FacilityId = 0;
            ShortName = string.Empty;
        }

        public int FacilityId { get; set; }
        public string ShortName { get; set; }
    }
}