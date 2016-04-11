using System.Collections.Generic;
using CommonDataRetrieval.Administration;
using ManagementRetrieval.Administration;

namespace ViewData.Administration
{
    public class HearAboutUsViewModel
    {
        public HearAboutUsViewModel()
        {
            using (AdministrationGetManager mgr = new AdministrationGetManager())
            {
                ListEntity = mgr.GetHearAboutUsList();
            }
        }

        public List<HearAboutUs> ListEntity { get; set; }
    }
}