namespace ClaudeCommon.Models.SiteConfiguration
{
    public class ModuleUsage
    {
        public ModuleUsage()
        {
            ModuleUsageId = 0;
            UseFundRaising = false;
            UseStudyCosting = false;
            AllowCustomEmail = false;
            UseSensoryStudies = false;
            UseProjectRequestForms = false;
            UseFacilitiesUtilization = false;
        }

        public int ModuleUsageId { get; set; }

        public bool UseFundRaising { get; set; }
        public bool UseStudyCosting { get; set; }
        public bool AllowCustomEmail { get; set; }
        public bool UseSensoryStudies { get; set; }
        public bool UseProjectRequestForms { get; set; }
        public bool UseFacilitiesUtilization { get; set; }
    }
}