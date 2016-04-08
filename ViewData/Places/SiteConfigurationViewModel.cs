using System.Collections.Generic;
using System.Web.Mvc;
using CommonDataRetrieval.Facility;
using CommonDataRetrieval.SiteConfiguration;
using DataLayerRetrieval.Facility;
using DataLayerRetrieval.Lookup;
using DataLayerRetrieval.SiteConfiguration;
using ManagementRetrieval.Facility;

namespace ViewData.Places
{
    public class SiteConfigurationViewModel
    {
        public SiteConfigurationViewModel()
        {
            using (DbFacilityGetList db = new DbFacilityGetList())
            {
                Facilities = db.GetList();
            }
            using (DbSiteConfigurationGet db = new DbSiteConfigurationGet())
            {
                SiteConfiguration = db.GetSiteConfiguration();
            }
            using (LuCompensationTypeLookup db = new LuCompensationTypeLookup())
            {
                CompensationTypes = db.LookupList;
            }
            using (FacilityResourceGetManager mgr = new FacilityResourceGetManager())
            {
                FacilityResources = mgr.GetList();
            }
        }

        public List<FacilityList> Facilities { get; set; }
        public SiteConfigurationGet SiteConfiguration { get; set; }
        public List<SelectListItem> CompensationTypes { get; set; }
        public List<FacilityResource> FacilityResources { get; set; }
    }
}