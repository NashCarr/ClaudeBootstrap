using ViewDataCommon.Base;

namespace CommonData.Models.Facility
{
    public class FacilityResource : AdministrationBase
    {
        public FacilityResource()
        {
            FacilityId = 0;
            ShortName = string.Empty;
            FacilityName = string.Empty;
        }

        public int FacilityId { get; set; }
        public string ShortName { get; set; }
        public string FacilityName { get; set; }
    }
}