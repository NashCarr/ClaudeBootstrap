using System.Collections.Generic;
using System.Web.Mvc;
using ClaudeCommon.Models.Facility;
using ClaudeCommon.Models.SiteConfiguration;
using ClaudeViewManagement.Managers.Facility;
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
            using (FacilityResourceManager mgr = new FacilityResourceManager())
            {
                FacilityResources = mgr.GetList();
            }
        }

        public PlaceListViewModel Facilities { get; set; }
        public SiteConfiguration SiteConfiguration { get; set; }
        public List<SelectListItem> CompensationTypes { get; set; }
        public List<FacilityResource> FacilityResources { get; set; }
    }
}