using System.Collections.Generic;
using System.Web.Mvc;
using CommonDataRetrieval.Facility;
using CommonDataRetrieval.SiteConfiguration;
using ManagementLookup;
using ManagementRetrieval.Facility;
using ManagementRetrieval.Places;

namespace ViewData.Places
{
    public class SiteConfigurationViewModel
    {
        public SiteConfigurationViewModel()
        {
            using (LookupManager mgr = new LookupManager())
            {
                CompensationTypes = mgr.GetCompensationTypes();
            }
            using (FacilityGetManager mgr = new FacilityGetManager())
            {
                Facilities = mgr.GetFacilityList();
            }
            using (FacilityResourceGetManager mgr = new FacilityResourceGetManager())
            {
                FacilityResources = mgr.GetList();
            }
            using (SiteConfigurationGetManager mgr = new SiteConfigurationGetManager())
            {
                SiteConfiguration = mgr.GetSiteConfiguration();
            }
        }

        public List<FacilityList> Facilities { get; set; }
        public SiteConfigurationGet SiteConfiguration { get; set; }
        public List<SelectListItem> CompensationTypes { get; set; }
        public List<FacilityResource> FacilityResources { get; set; }
    }
}