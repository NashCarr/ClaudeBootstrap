using System.Collections.Generic;
using System.Web.Mvc;
using ClaudeCommon.Models;
using ClaudeData.Models.LookupLists;
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
            }
            TimeZones = new TimeZoneLookupList().LookupList;
        }
        public List<Place> ListEntity { get; set; }
        public List<SelectListItem> TimeZones { get; set; }
    }
}