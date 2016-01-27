using ClaudeData.BaseModels;

namespace ClaudeData.Models.Admin
{
    public class FacilityResource : AdminBase
    {
        public FacilityResource()
        {
            FacilityId = 0;
        }

        public int FacilityId { get; set; }
    }
}