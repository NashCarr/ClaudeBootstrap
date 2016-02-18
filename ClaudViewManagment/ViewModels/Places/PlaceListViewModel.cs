﻿using System.Collections.Generic;
using System.Web.Mvc;
using ClaudeCommon.Models;
using ClaudeViewManagement.Managers.Places;
using static ClaudeCommon.Enums.PlaceEnums;

namespace ClaudeViewManagement.ViewModels.Places
{
    public class PlaceListViewModel
    {
        public PlaceListViewModel(PlaceType pt)
        {
            using (PlaceManager mgr = new PlaceManager())
            {
                ListEntity = mgr.GetList(pt);
                Countries = mgr.GetCountries();
                TimeZones = mgr.GetTimeZones();
                MobileCarriers = mgr.GetMobileCarriers();
                StatesProvinces = mgr.GetStatesProvinces();
            }
        }
        public List<Place> ListEntity { get; set; }
        public List<SelectListItem> TimeZones { get; set; }
        public List<SelectListItem> Countries { get; set; }
        public List<SelectListItem> MobileCarriers { get; set; }
        public List<SelectListItem> StatesProvinces { get; set; }
    }
}