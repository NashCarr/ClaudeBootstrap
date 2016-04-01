using System.Collections.Generic;
using System.Web.Mvc;

namespace DataManagement.Models.LookupLists
{
    public class PersonLookupList
    {
        public PersonLookupList()
        {
            LookupList = new List<SelectListItem>();
        }

        public List<SelectListItem> LookupList { get; set; }
    }
}