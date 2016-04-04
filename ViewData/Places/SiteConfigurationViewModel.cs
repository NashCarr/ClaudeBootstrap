using System.Collections.Generic;
using System.Web.Mvc;
using DataCommon.SiteConfiguration;
using DataLayerCommon.Enums;
using DataLayerCommon.LookupLists;
using DataLayerRetrieval.SiteConfiguration;
using ManagementRetrieval.Facility;
using ViewDataCommon.Facility;

namespace ViewData.Places
{
    public class SiteConfigurationViewModel
    {
        public SiteConfigurationViewModel()
        {
            Facilities = new PlaceListViewModel(PlaceEnums.PlaceType.Facility);
            using (DbSiteConfigurationGet db = new DbSiteConfigurationGet())
            {
                SiteConfiguration = db.GetSiteConfiguration();
            }
            using (CompensationTypeLookupList db = new CompensationTypeLookupList())
            {
                CompensationTypes = db.LookupList;
            }
            using (FacilityResourceGetManager mgr = new FacilityResourceGetManager())
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