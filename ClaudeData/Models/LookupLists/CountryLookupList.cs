using System.Collections.Generic;
using System.Web.Mvc;
using ClaudeCommon.Helpers;
using static ClaudeCommon.Enums.CountryEnums;

namespace ClaudeData.Models.LookupLists
{
    public class CountryLookupList
    {
        public CountryLookupList()
        {
            LookupList = new List<SelectListItem>(EnumHelpers.SelectListFor<Country>());
            foreach (SelectListItem item in LookupList)
            {
                item.Value = EnumHelpers.GetShortFromEnum<Country>(item.Value).ToString();
            }
        }

        public List<SelectListItem> LookupList { get; set; }
    }
}