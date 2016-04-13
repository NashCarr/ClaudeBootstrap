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
                Screeners = mgr.ScreenerList;
                ActiveStudies = mgr.ActiveList;
                CompletedStudies = mgr.CompletedList;
            }
        }

        public List<ResearchStudy> Screeners { get; set; }
        public List<ResearchStudy> ActiveStudies { get; set; }
        public List<ResearchStudy> CompletedStudies { get; set; }
    }
}