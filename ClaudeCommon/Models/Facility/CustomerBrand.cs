using ClaudeCommon.Models.Administration;

namespace ClaudeCommon.Models.Facility
{
    public class FacilityResource : AdministrationBase
    {
        public FacilityResource()
        {
            FacilityId = 0;
        }

        public int FacilityId { get; set; }
    }
}