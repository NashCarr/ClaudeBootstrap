using CommonDataRetrieval.Base;

namespace CommonDataRetrieval.Research
{
    public class ResearchDashboard : ModelBase
    {
        public ResearchDashboard()
        {
            OpenDate = string.Empty;
            CloseDate = string.Empty;
            ProjectNumber = string.Empty;
        }

        public string OpenDate { get; set; }
        public string CloseDate { get; set; }
        public string ProjectNumber { get; set; }
    }
}