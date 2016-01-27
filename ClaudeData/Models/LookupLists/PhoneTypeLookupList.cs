using System.Collections.Generic;
using System.Web.Mvc;
using ClaudeCommon.Helpers;
using static ClaudeCommon.Enums.PhoneEnums;

namespace ClaudeData.Models.LookupLists
{
    public class PhoneTypeLookupList
    {
        public PhoneTypeLookupList()
        {
            LookupList = new List<SelectListItem>(EnumHelpers.SelectListFor<PhoneType>());
            foreach (SelectListItem item in LookupList)
            {
                item.Value = EnumHelpers.GetByteFromEnum<PhoneType>(item.Value).ToString();
            }
        }

        public List<SelectListItem> LookupList { get; set; }
    }
}