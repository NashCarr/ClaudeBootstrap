using System.Collections.Generic;
using System.Web.Mvc;
using CommonDataRetrieval.Places;
using DataLayerRetrieval.LookupModel;
using ManagementLookup;
using ManagementRetrieval.Places;
using static CommonData.Enums.PlaceEnums;

namespace ViewData.Places
{
    public class PlaceListViewModel
    {
        public PlaceListViewModel(PlaceType pt)
        {
            using (PlaceListGetManager mgr = new PlaceListGetManager())
            {
                ListEntity = mgr.GetPlaceList(pt);
            }
            using (LookupManager mgr = new LookupManager())
            {
                Countries = mgr.GetCountries();
                TimeZones = mgr.GetTimeZones();
                PostalCodes = mgr.GetPostalCodes();
                MobileCarriers = mgr.GetMobileCarriers();
                StatesProvinces = mgr.GetStatesProvinces();
            }
        }

        public List<PlaceList> ListEntity { get; set; }
        public List<SelectListItem> TimeZones { get; set; }
        public List<SelectListItem> Countries { get; set; }
        public List<PostalCodeLookup> PostalCodes { get; set; }
        public List<SelectListItem> MobileCarriers { get; set; }
        public List<SelectListItem> StatesProvinces { get; set; }
    }
}