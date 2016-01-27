using System.Collections.Generic;
using System.Web.Mvc;

namespace ClaudeData.Models.LookupLists
{
    public class MobileCarrierLookupList
    {
        public MobileCarrierLookupList()
        {
            LookupList = new List<SelectListItem>
            {
                new SelectListItem {Text = "None", Value = "0"},
                new SelectListItem {Text = "ATT", Value = "1"},
                new SelectListItem {Text = "Verizon", Value = "2"}
            };
        }

        public List<SelectListItem> LookupList { get; set; }
    }
}