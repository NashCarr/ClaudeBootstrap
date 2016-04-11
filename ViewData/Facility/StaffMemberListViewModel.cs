using System.Collections.Generic;
using System.Web.Mvc;
using CommonDataLookup;
using CommonDataRetrieval.Places;
using ManagementLookup;
using ManagementRetrieval.People;

namespace ViewData.Facility
{
    public class StaffMemberListViewModel
    {
        public StaffMemberListViewModel()
        {
            using (StaffMemberListGetManager mgr = new StaffMemberListGetManager())
            {
                ListEntity = mgr.GetList();
            }
            using (LookupManager mgr = new LookupManager())
            {
                Countries = mgr.GetCountries();
                TimeZones = mgr.GetTimeZones();
                Facilities = mgr.GetFacilities();
                PostalCodes = mgr.GetPostalCodes();
                MobileCarriers = mgr.GetMobileCarriers();
                StatesProvinces = mgr.GetStatesProvinces();
            }
        }

        public List<SelectListItem> TimeZones { get; set; }
        public List<SelectListItem> Countries { get; set; }
        public List<SelectListItem> Facilities { get; set; }
        public List<StaffMember> ListEntity { get; set; }
        public List<PostalCodeLookup> PostalCodes { get; set; }
        public List<SelectListItem> MobileCarriers { get; set; }
        public List<SelectListItem> StatesProvinces { get; set; }
    }
}