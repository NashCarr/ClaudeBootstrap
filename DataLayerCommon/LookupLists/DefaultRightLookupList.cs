using System.Collections.Generic;
using System.Web.Mvc;
using static DataLayerCommon.Enums.AdministrationEnums;
using static DataLayerCommon.Helpers.EnumHelpers;

namespace DataLayerCommon.LookupLists
{
    public class DefaultRightLookupList
    {
        public DefaultRightLookupList()
        {
            LookupList = new List<SelectListItem>(SelectListFor<DefaultRight>());
            foreach (SelectListItem item in LookupList)
            {
                item.Value = GetByteFromEnum<DefaultRight>(item.Value).ToString();
            }
        }

        public List<SelectListItem> LookupList { get; set; }
    }
}