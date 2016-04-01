using System.Collections.Generic;
using System.Web.Mvc;

namespace DataManagement.Models.LookupLists
{
    public class ProgramOptionLookupList
    {
        public ProgramOptionLookupList()
        {
            LookupList = new List<SelectListItem>();
        }

        public List<SelectListItem> LookupList { get; set; }
    }
}