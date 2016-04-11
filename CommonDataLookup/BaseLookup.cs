using System.Collections.Generic;
using System.Web.Mvc;

namespace CommonDataLookup
{
    public class BaseLookup
    {
        public BaseLookup()
        {
            LookupList = new List<SelectListItem>();
        }

        public List<SelectListItem> LookupList { get; set; }
    }
}