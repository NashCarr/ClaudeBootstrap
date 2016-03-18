namespace ClaudeData.Models.SiteConfiguration
{
    public abstract class Compensation
    {
        protected Compensation()
        {
            StudyAmount = 0;
            DollarsPerPoint = 0;
            CompensationType = 0;
            UseCompensation = false;
            StudyCompensationType = 0;
            RedeemPointsMultiples = 0;
        }

        public decimal StudyAmount { get; set; }
        public decimal DollarsPerPoint { get; set; }

        public short CompensationType { get; set; }
        public short StudyCompensationType { get; set; }
        public short RedeemPointsMultiples { get; set; }

        public bool UseCompensation { get; set; }
    }
}