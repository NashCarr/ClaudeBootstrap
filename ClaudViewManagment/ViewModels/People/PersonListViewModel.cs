﻿using System.Collections.Generic;
using System.Web.Mvc;
using ClaudeCommon.Models.People;
using ClaudeData.Models.LookupLists;
using ClaudeViewManagement.Managers.People;
using ClaudeViewManagement.Managers.Shared;
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
                Facilities = mgr.GetFacilities();
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