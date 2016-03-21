namespace ClaudeCommon.Models.SiteConfiguration
{
    public class AssessorCompensation : Compensation
    {
        public AssessorCompensation()
        {
            AssessorCompensationId = 0;
        }

        public int AssessorCompensationId { get; set; }

        public decimal ReferralAmount { get; set; }
        public decimal RegistrationAmount { get; set; }
        public decimal OrganizationAmount { get; set; }

        public short ReferralCompensationType { get; set; }
        public short RegistrationCompensationType { get; set; }
        public short OrganizationCompensationType { get; set; }
    }
}