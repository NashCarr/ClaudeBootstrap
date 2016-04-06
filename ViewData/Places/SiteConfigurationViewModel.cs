using System.Collections.Generic;
using System.Web.Mvc;
using CommonDataRetrieval.Facility;
using CommonDataRetrieval.SiteConfiguration;
using DataLayerRetrieval.Lookup;
using DataLayerRetrieval.SiteConfiguration;
using ManagementRetrieval.Facility;
using static CommonData.Enums.PlaceEnums;

namespace ViewData.Places
{
    public class SiteConfigurationViewModel
    {
        public SiteConfigurationViewModel()
        {
            Facilities = new PlaceListViewModel(PlaceType.Facility);
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

        public PlaceListViewModel Facilities { get; set; }
        public SiteConfigurationGet SiteConfiguration { get; set; }
        public List<SelectListItem> CompensationTypes { get; set; }
        public List<FacilityResource> FacilityResources { get; set; }
    }
}