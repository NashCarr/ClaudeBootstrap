using System.Collections.Generic;
using CommonDataRetrieval.Research;
using ManagementRetrieval.Research;

namespace ViewData.Research
{
    public class ResearchDashboardViewModel
    {
        public ResearchDashboardViewModel()
        {
            using (ResearchDashboardGetManager mgr = new ResearchDashboardGetManager())
            {
                ListEntity = mgr.GetResearchDashboardList();
            }
        }

        public List<ResearchDashboard> ListEntity { get; set; }
    }
}