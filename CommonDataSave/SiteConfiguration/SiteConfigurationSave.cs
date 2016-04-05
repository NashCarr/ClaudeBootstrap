using DataLayerCommon.SiteConfiguration;

namespace CommonDataSave.SiteConfiguration
{
    public class SiteConfigurationSave
    {
        public SiteConfigurationSave()
        {
            ModuleUsage = new ModuleUsage();
            StudyDefinitions = new StudyDefinition();
            PasswordRequirements = new PasswordRequirement();
            GeneralConfiguration = new GeneralConfiguration();
            AssessorCompensation = new AssessorCompensation();
            EmployeeCompensation = new EmployeeCompensation();
        }

        public ModuleUsage ModuleUsage { get; set; }
        public PasswordRequirement PasswordRequirements { get; set; }
        public StudyDefinition StudyDefinitions { get; set; }
        public GeneralConfiguration GeneralConfiguration { get; set; }
        public AssessorCompensation AssessorCompensation { get; set; }
        public EmployeeCompensation EmployeeCompensation { get; set; }
    }
}