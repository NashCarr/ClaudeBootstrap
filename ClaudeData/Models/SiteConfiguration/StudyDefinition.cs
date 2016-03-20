namespace ClaudeData.Models.SiteConfiguration
{
    public class StudyDefinition
    {
        public StudyDefinition()
        {
            Budget = false;
            Overview = false;
            StudyDefinitionId = 0;
            CustomerBrands = false;
            ExternalSpending = false;
            CustomerContacts = false;
            FoodRequirements = false;
            ResearchObjective = false;
            OtherRequirements = false;
            ScreeningCriteria = false;
            ContractorRequirements = false;
            AudioVisualRequirements = false;
        }

        public int StudyDefinitionId { get; set; }

        public bool Budget { get; set; }
        public bool Overview { get; set; }
        public bool CustomerBrands { get; set; }
        public bool ExternalSpending { get; set; }
        public bool CustomerContacts { get; set; }
        public bool FoodRequirements { get; set; }
        public bool ResearchObjective { get; set; }
        public bool OtherRequirements { get; set; }
        public bool ScreeningCriteria { get; set; }
        public bool ContractorRequirements { get; set; }
        public bool AudioVisualRequirements { get; set; }
    }
}