namespace CommonData.Models.SiteConfiguration
{
    public class GeneralConfiguration
    {
        public GeneralConfiguration()
        {
            OneStudy = false;
            LimitIrs1099 = false;
            Irs1099MaxAmount = 0;
            NoShowSuspendDays = 0;
            NoShowSuspendCount = 0;
            UnmarkedClosingStatus = 0;
            PastParticipationDays = 0;
            GeneralConfigurationId = 0;
            OneStudyPerHousehold = false;
            UsePregnancyQuestion = false;
            DaysBetweenEmailsToAssessor = 0;
            ClaudeUnmarkedClosingStatus = 0;
            NewFundOrgStaffEmail = string.Empty;
            TrainedPanelStaffEmail = string.Empty;
        }

        public int GeneralConfigurationId { get; set; }

        public bool OneStudy { get; set; }
        public bool LimitIrs1099 { get; set; }
        public bool OneStudyPerHousehold { get; set; }
        public bool UsePregnancyQuestion { get; set; }

        public decimal Irs1099MaxAmount { get; set; }

        public short NoShowSuspendDays { get; set; }
        public short NoShowSuspendCount { get; set; }
        public short UnmarkedClosingStatus { get; set; }
        public short PastParticipationDays { get; set; }
        public short DaysBetweenEmailsToAssessor { get; set; }
        public short ClaudeUnmarkedClosingStatus { get; set; }

        public string NewFundOrgStaffEmail { get; set; }
        public string TrainedPanelStaffEmail { get; set; }
    }
}