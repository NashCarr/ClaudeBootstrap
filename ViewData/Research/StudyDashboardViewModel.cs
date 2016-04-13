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
                StudyDashboard = mgr.GetStudyDashboardList();
            }
        }

        public StudyDashboard StudyDashboard { get; set; }
    }
}