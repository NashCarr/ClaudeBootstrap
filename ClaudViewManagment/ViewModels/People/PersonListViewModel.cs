using System.Collections.Generic;
using System.Web.Mvc;
using ClaudeCommon.Models;
using ClaudeData.Models.LookupLists;
using ClaudeViewManagement.Managers.People;
using static ClaudeCommon.Enums.PersonEnums;

namespace ClaudeViewManagement.ViewModels.People
{
    public class PersonListViewModel
    {
        public PersonListViewModel(PersonType pt)
        {
            using (PersonListManager mgr = new PersonListManager())
            {
                ListEntity = mgr.GetList(pt);
                Countries = mgr.GetCountries();
                TimeZones = mgr.GetTimeZones();
                Facilities = mgr.GetFacilities();
                PostalCodes = mgr.GetPostalCodes();
                MobileCarriers = mgr.GetMobileCarriers();
                StatesProvinces = mgr.GetStatesProvinces();
            }
        }

        public List<PersonList> ListEntity { get; set; }
        public List<SelectListItem> TimeZones { get; set; }
        public List<SelectListItem> Countries { get; set; }
        public List<SelectListItem> Facilities { get; set; }
        public List<PostalCodeLookup> PostalCodes { get; set; }
        public List<SelectListItem> MobileCarriers { get; set; }
        public List<SelectListItem> StatesProvinces { get; set; }
    }
}