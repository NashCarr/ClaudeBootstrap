using System.Collections.Generic;
using System.Web.Mvc;

namespace DataLayerRetrieval.LookupModel
{
    public class ProgramOptionLookup
    {
        public ProgramOptionLookup()
        {
            LookupList = new List<SelectListItem>();
        }

        public List<SelectListItem> LookupList { get; set; }
    }
}