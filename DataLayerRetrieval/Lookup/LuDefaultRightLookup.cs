using System.Collections.Generic;
using System.Web.Mvc;
using CommonData.Enums;
using DataLayerCommon.Helpers;

namespace DataLayerRetrieval.Lookup
{
    public class LuDefaultRightLookup
    {
        public LuDefaultRightLookup()
        {
            LookupList = new List<SelectListItem>(EnumHelpers.SelectListFor<AdministrationEnums.DefaultRight>());
            foreach (SelectListItem item in LookupList)
            {
                item.Value = EnumHelpers.GetByteFromEnum<AdministrationEnums.DefaultRight>(item.Value).ToString();
            }
        }

        public List<SelectListItem> LookupList { get; set; }
    }
}