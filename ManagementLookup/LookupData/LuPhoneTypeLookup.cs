using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CommonData.Enums;
using CommonData.Helpers;

namespace ManagementLookup.LookupData
{
    public class LuPhoneTypeLookup : IDisposable
    {
        public LuPhoneTypeLookup()
        {
            LookupList =
                new List<SelectListItem>(
                    EnumHelpers.SelectListFor<PhoneEnums.PhoneType>()
                        .Where(e => e.Value != PhoneEnums.PhoneType.None.ToString()));
            foreach (SelectListItem item in LookupList)
            {
                item.Value = EnumHelpers.GetByteFromEnum<PhoneEnums.PhoneType>(item.Value).ToString();
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