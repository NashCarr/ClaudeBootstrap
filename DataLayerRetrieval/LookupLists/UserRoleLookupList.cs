using System.Collections.Generic;
using System.Web.Mvc;

namespace DataLayerRetrieval.LookupLists
{
    public class UserRoleLookupList
    {
        public UserRoleLookupList()
        {
            LookupList = new List<SelectListItem>();
        }

        public List<SelectListItem> LookupList { get; set; }
    }
}