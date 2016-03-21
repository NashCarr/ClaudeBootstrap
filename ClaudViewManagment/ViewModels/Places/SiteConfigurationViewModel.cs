using System.Collections.Generic;
using System.Web.Mvc;
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
                CompensationTypes = mgr.GetCompensationTypes();
            }
        }

        public PlaceListViewModel Facilities { get; set; }
        public SiteConfiguration SiteConfiguration { get; set; }
        public List<SelectListItem> CompensationTypes { get; set; }
    }
}