using System.Collections.Generic;
using System.Web.Mvc;
using CommonData.Helpers;
using static CommonData.Enums.AdministrationEnums;

namespace ManagementLookup.LookupData
{
    public class LuDefaultRightLookup
    {
        public LuDefaultRightLookup()
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