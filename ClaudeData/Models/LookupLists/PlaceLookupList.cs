using System.Collections.Generic;
using System.Web.Mvc;

namespace DataManagement.Models.LookupLists
{
    public class PlaceLookupList
    {
        public PlaceLookupList()
        {
            LookupList = new List<SelectListItem>();
        }

        public List<SelectListItem> LookupList { get; set; }
    }
}