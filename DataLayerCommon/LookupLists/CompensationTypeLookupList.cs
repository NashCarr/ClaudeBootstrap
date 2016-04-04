using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CommonData.Enums;
using EnumHelpers = DataLayerCommon.Helpers.EnumHelpers;

namespace DataLayerCommon.LookupLists
{
    public class CompensationTypeLookupList : IDisposable
    {
        public CompensationTypeLookupList()
        {
            LookupList =
                new List<SelectListItem>(
                    EnumHelpers.SelectListFor<StudyEnums.CompensationType>()
                        .Where(e => e.Value != StudyEnums.CompensationType.None.ToString()));
            foreach (SelectListItem item in LookupList)
            {
                item.Value = EnumHelpers.GetByteFromEnum<StudyEnums.CompensationType>(item.Value).ToString();
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