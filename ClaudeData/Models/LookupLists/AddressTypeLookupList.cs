using System.Collections.Generic;
using System.Web.Mvc;
using ClaudeCommon.Helpers;
using static ClaudeCommon.Enums.AddressEnums;

namespace ClaudeData.Models.LookupLists
{
    public class AddressTypeLookupList
    {
        public AddressTypeLookupList()
        {
            LookupList = new List<SelectListItem>(EnumHelpers.SelectListFor<AddressType>());
            foreach (SelectListItem item in LookupList)
            {
                item.Value = EnumHelpers.GetByteFromEnum<AddressType>(item.Value).ToString();
            }
        }

        public List<SelectListItem> LookupList { get; set; }
    }
}