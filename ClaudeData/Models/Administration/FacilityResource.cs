using ClaudeData.BaseModels;

namespace ClaudeData.Models.Administration
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