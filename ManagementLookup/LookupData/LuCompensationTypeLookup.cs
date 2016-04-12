using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CommonData.Helpers;
using static CommonData.Enums.StudyEnums;

namespace ManagementLookup.LookupData
{
    public class LuCompensationTypeLookup : IDisposable
    {
        public LuCompensationTypeLookup()
        {
            LookupList =
                new List<SelectListItem>(EnumHelpers.SelectListFor<CompensationType>()
                    .Where(e => e.Value != CompensationType.None.ToString()));
            foreach (SelectListItem item in LookupList)
            {
                item.Value = EnumHelpers.GetByteFromEnum<CompensationType>(item.Value).ToString();
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