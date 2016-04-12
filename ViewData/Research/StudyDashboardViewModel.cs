using System.Collections.Generic;
using CommonDataRetrieval.Research;
using ManagementRetrieval.Research;

namespace ViewData.Research
{
    public class StudyDashboardViewModel
    {
        public StudyDashboardViewModel()
        {
            using (StudyDashboardGetManager mgr = new StudyDashboardGetManager())
            {
                ListEntity = mgr.GetStudyDashboardList();
            }
        }

        public List<StudyDashboard> ListEntity { get; set; }
    }
}