using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CommonData.Helpers;
using static CommonData.Enums.AddressEnums;

namespace ManagementLookup.LookupData
{
    public class LuAddressTypeLookup : IDisposable
    {
        public LuAddressTypeLookup()
        {
            LookupList =
                new List<SelectListItem>(
                    EnumHelpers.SelectListFor<AddressType>()
                        .Where(e => e.Value != AddressType.None.ToString()));
            foreach (SelectListItem item in LookupList)
            {
                item.Value = EnumHelpers.GetByteFromEnum<AddressType>(item.Value).ToString();
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