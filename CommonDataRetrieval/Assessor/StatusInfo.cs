using CommonDataRetrieval.Base;
using static CommonData.Enums.AssessorEnums;

namespace CommonDataRetrieval.Assessor
{
    public class StatusInfo : ModelBase
    {
        public StatusInfo()
        {
            Status = AssessorStatus.None;
            LastLoginDate = string.Empty;
            RegistrationDate = string.Empty;
            LastParticipationDate = string.Empty;
        }

        public string LastLoginDate { get; set; }
        public AssessorStatus Status { get; set; }
        public string RegistrationDate { get; set; }
        public string LastParticipationDate { get; set; }
    }
}