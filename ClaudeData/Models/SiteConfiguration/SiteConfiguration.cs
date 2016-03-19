namespace ClaudeData.Models.SiteConfiguration
{
    public class SiteConfiguration
    {
        public SiteConfiguration()
        {
            Modules = new ModuleUsage();
            General = new GeneralConfiguration();
            Passwords = new PasswordRequirement();
            AssessorComp = new AssessorCompensation();
            EmployeeComp = new EmployeeCompensation();
        }

        public ModuleUsage Modules { get; set; }
        public GeneralConfiguration General { get; set; }
        public PasswordRequirement Passwords { get; set; }
        public StudyDefinition StudyDefinitions { get; set; }
        public AssessorCompensation AssessorComp { get; set; }
        public EmployeeCompensation EmployeeComp { get; set; }
    }
}