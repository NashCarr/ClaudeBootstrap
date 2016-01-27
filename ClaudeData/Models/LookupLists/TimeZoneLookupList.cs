using System.Collections.Generic;
using System.Web.Mvc;
using ClaudeCommon.Helpers;
using static ClaudeCommon.Enums.TimeZoneEnums;

namespace ClaudeData.Models.LookupLists
{
    public class TimeZoneLookupList
    {
        public TimeZoneLookupList()
        {
            LookupList = new List<SelectListItem>(EnumHelpers.SelectListFor<ClaudeTimeZone>());
            foreach (SelectListItem item in LookupList)
            {
                item.Value = EnumHelpers.GetByteFromEnum<ClaudeTimeZone>(item.Value).ToString();
            }
        }

        public List<SelectListItem> LookupList { get; set; }
    }
}