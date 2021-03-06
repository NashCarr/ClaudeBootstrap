﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CommonData.Helpers;
using static CommonData.Enums.CountryEnums;

namespace ManagementLookup.LookupData
{
    public class LuCountryLookup : IDisposable
    {
        public LuCountryLookup()
        {
            LookupList =
                new List<SelectListItem>(
                    EnumHelpers.SelectListFor<Country>()
                        .Where(e => e.Value != Country.None.ToString()));
            foreach (SelectListItem item in LookupList)
            {
                item.Value = EnumHelpers.GetShortFromEnum<Country>(item.Value).ToString();
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