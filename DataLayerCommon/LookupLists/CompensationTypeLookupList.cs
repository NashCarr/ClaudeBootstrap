﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DataLayerCommon.Helpers;
using static DataLayerCommon.Enums.StudyEnums;

namespace DataLayerCommon.LookupLists
{
    public class CompensationTypeLookupList : IDisposable
    {
        public CompensationTypeLookupList()
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