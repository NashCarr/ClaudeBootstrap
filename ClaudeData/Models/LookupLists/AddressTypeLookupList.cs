using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CommonData.Enums;
using CommonData.Helpers;

namespace ManagementLookup.LookupLists
{
    public class AddressTypeLookupList : IDisposable
    {
        public AddressTypeLookupList()
        {
            LookupList =
                new List<SelectListItem>(
                    EnumHelpers.SelectListFor<AddressEnums.AddressType>()
                        .Where(e => e.Value != AddressEnums.AddressType.None.ToString()));
            foreach (SelectListItem item in LookupList)
            {
                item.Value = EnumHelpers.GetByteFromEnum<AddressEnums.AddressType>(item.Value).ToString();
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