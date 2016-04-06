using System.Collections.Generic;
using System.Web.Mvc;

namespace DataLayerRetrieval.LookupModel
{
    public class PlaceLookup
    {
        public PlaceLookup()
        {
            LookupList = new List<SelectListItem>();
        }

        public List<SelectListItem> LookupList { get; set; }
    }
}