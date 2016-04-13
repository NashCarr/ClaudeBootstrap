using CommonDataRetrieval.Base;
using static CommonData.Enums.StudyEnums;

namespace CommonDataRetrieval.Research
{
    public class ResearchStudy : ModelBase
    {
        public ResearchStudy()
        {
            OpenDate = string.Empty;
            CloseDate = string.Empty;
            ProjectNumber = string.Empty;
            Status = StudyStatus.Requested;
        }

        public string OpenDate { get; set; }
        public string CloseDate { get; set; }
        public StudyStatus Status { get; set; }
        public string ProjectNumber { get; set; }
    }
}