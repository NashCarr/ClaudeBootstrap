using System.Collections.Generic;
using System.Web.Mvc;
using ClaudeCommon.Models.Places;
using ClaudeData.Models.LookupLists;
using ClaudeViewManagement.Managers.Places;
using ClaudeViewManagement.Managers.Shared;
using static ClaudeCommon.Enums.PlaceEnums;

namespace ClaudeViewManagement.ViewModels.Places
{
    public class PlaceListViewModel
    {
        public PlaceListViewModel(PlaceType pt)
        {
            using (PlaceListManager mgr = new PlaceListManager())
            {
                ListEntity = mgr.GetList(pt);
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