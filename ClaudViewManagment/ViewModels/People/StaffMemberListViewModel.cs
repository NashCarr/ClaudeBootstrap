﻿using System.Collections.Generic;
using System.Web.Mvc;
using ClaudeCommon.Models.Facility;
using ClaudeData.Models.LookupLists;
using ClaudeViewManagement.Managers.People;
using ClaudeViewManagement.Managers.Shared;

namespace ClaudeViewManagement.ViewModels.People
{
    public class StaffMemberListViewModel
    {
        public StaffMemberListViewModel()
        {
            using (StaffMemberListManager mgr = new StaffMemberListManager())
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
        public List<StaffMemberList> ListEntity { get; set; }
        public List<PostalCodeLookup> PostalCodes { get; set; }
        public List<SelectListItem> MobileCarriers { get; set; }
        public List<SelectListItem> StatesProvinces { get; set; }
    }
}