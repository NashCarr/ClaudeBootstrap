using System.Collections.Generic;
using System.Web.Mvc;
using CommonDataRetrieval.People;
using DataLayerRetrieval.LookupModel;
using ManagementLookup;
using ManagementRetrieval.People;
using static CommonData.Enums.PersonEnums;

namespace ViewData.People
{
    public class PersonListViewModel
    {
        public PersonListViewModel(PersonType pt)
        {
            using (PersonListGetManager mgr = new PersonListGetManager())
            {
                ListEntity = mgr.GetList(pt);
                Facilities = mgr.GetFacilitiesLookup();
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

        public List<PersonList> ListEntity { get; set; }
        public List<SelectListItem> TimeZones { get; set; }
        public List<SelectListItem> Countries { get; set; }
        public List<SelectListItem> Facilities { get; set; }
        public List<PostalCodeLookup> PostalCodes { get; set; }
        public List<SelectListItem> MobileCarriers { get; set; }
        public List<SelectListItem> StatesProvinces { get; set; }
    }
}