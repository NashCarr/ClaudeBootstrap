namespace ClaudeCommon.Models.SiteConfiguration
{
    public class EmployeeCompensation : Compensation
    {
        public EmployeeCompensation()
        {
            EmployeeCompensationId = 0;
        }

        public int EmployeeCompensationId { get; set; }
    }
}