using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DataLayerCommon.Helpers;
using static DataLayerCommon.Enums.AddressEnums;

namespace ManagementLookup.LookupData
{
    public class AddressTypeLookupList : IDisposable
    {
        public AddressTypeLookupList()
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