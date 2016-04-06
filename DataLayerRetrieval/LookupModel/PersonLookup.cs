using System.Collections.Generic;
using System.Web.Mvc;

namespace DataLayerRetrieval.LookupModel
{
    public class PersonLookup
    {
        public PersonLookup()
        {
            LookupList = new List<SelectListItem>();
        }

        public List<SelectListItem> LookupList { get; set; }
    }
}