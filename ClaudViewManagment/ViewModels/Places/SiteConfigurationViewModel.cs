using ClaudeCommon.Models.SiteConfiguration;
using ClaudeViewManagement.Managers.Places;
using static ClaudeCommon.Enums.PlaceEnums;

namespace ClaudeViewManagement.ViewModels.Places
{
    public class SiteConfigurationViewModel
    {
        public SiteConfigurationViewModel()
        {
            Facilities = new PlaceListViewModel(PlaceType.Facility);
            using (SiteConfigurationManager mgr = new SiteConfigurationManager())
            {
                SiteConfiguration = mgr.GetSiteConfiguration();
            }
        }

        public PlaceListViewModel Facilities { get; set; }
        public SiteConfiguration SiteConfiguration { get; set; }
    }
}