using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CommonData.Enums;
using CommonData.Helpers;

namespace DataManagement.Models.LookupLists
{
    public class CountryLookupList : IDisposable
    {
        public CountryLookupList()
        {
            LookupList =
                new List<SelectListItem>(
                    EnumHelpers.SelectListFor<CountryEnums.Country>().Where(e => e.Value != CountryEnums.Country.None.ToString()));
            foreach (SelectListItem item in LookupList)
            {
                item.Value = EnumHelpers.GetShortFromEnum<CountryEnums.Country>(item.Value).ToString();
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