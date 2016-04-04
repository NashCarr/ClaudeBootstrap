using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DataLayerCommon.Enums;
using DataLayerCommon.Helpers;

namespace ManagementLookup.LookupData
{
    public class TimeZoneLookupList : IDisposable
    {
        public TimeZoneLookupList()
        {
            LookupList =
                new List<SelectListItem>(
                    EnumHelpers.SelectListFor<TimeZoneEnums.ClaudeTimeZone>()
                        .Where(e => e.Value != TimeZoneEnums.ClaudeTimeZone.None.ToString()));
            foreach (SelectListItem item in LookupList)
            {
                item.Value = EnumHelpers.GetByteFromEnum<TimeZoneEnums.ClaudeTimeZone>(item.Value).ToString();
            }
        }

        public List<SelectListItem> LookupList { get; set; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool iAmBeingCalledFromDisposeAndNotFinalize)
        {
        }
    }
}