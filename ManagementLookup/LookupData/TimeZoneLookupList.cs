using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DataLayerCommon.Helpers;
using static CommonData.Enums.TimeZoneEnums;

namespace ManagementLookup.LookupData
{
    public class TimeZoneLookupList : IDisposable
    {
        public TimeZoneLookupList()
        {
            LookupList =
                new List<SelectListItem>(
                    EnumHelpers.SelectListFor<ClaudeTimeZone>()
                        .Where(e => e.Value != ClaudeTimeZone.None.ToString()));
            foreach (SelectListItem item in LookupList)
            {
                item.Value = EnumHelpers.GetByteFromEnum<ClaudeTimeZone>(item.Value).ToString();
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