using System.Collections.Generic;
using System.Web.Mvc;
using CommonData.Enums;
using CommonData.Models.Facility;
using CommonData.Models.SiteConfiguration;
using ViewManagement.Managers.Facility;
using ViewManagement.Managers.Places;

namespace ViewManagement.ViewModels.Places
{
    public class SiteConfigurationViewModel
    {
        public SiteConfigurationViewModel()
        {
            Facilities = new PlaceListViewModel(PlaceEnums.PlaceType.Facility);
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