using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DataLayerCommon.Helpers;
using static CommonData.Enums.PhoneEnums;

namespace DataLayerRetrieval.LookupLists
{
    public class PhoneTypeLookupList : IDisposable
    {
        public PhoneTypeLookupList()
        {
            LookupList =
                new List<SelectListItem>(
                    EnumHelpers.SelectListFor<PhoneType>()
                        .Where(e => e.Value != PhoneType.None.ToString()));
            foreach (SelectListItem item in LookupList)
            {
                item.Value = EnumHelpers.GetByteFromEnum<PhoneType>(item.Value).ToString();
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