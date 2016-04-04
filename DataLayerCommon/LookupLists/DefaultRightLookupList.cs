using System.Collections.Generic;
using System.Web.Mvc;
using CommonData.Enums;
using EnumHelpers = DataLayerCommon.Helpers.EnumHelpers;

namespace DataLayerCommon.LookupLists
{
    public class DefaultRightLookupList
    {
        public DefaultRightLookupList()
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