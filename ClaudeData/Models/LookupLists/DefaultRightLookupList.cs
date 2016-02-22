using System.Collections.Generic;
using System.Web.Mvc;
using ClaudeCommon.Helpers;
using static ClaudeCommon.Enums.AdministrationEnums;

namespace ClaudeData.Models.LookupLists
{
    public class DefaultRightLookupList
    {
        public DefaultRightLookupList()
        {
            LookupList = new List<SelectListItem>(EnumHelpers.SelectListFor<DefaultRight>());
            foreach (SelectListItem item in LookupList)
            {
                item.Value = EnumHelpers.GetByteFromEnum<DefaultRight>(item.Value).ToString();
            }
        }
        public List<SelectListItem> LookupList { get; set; }
    }
}