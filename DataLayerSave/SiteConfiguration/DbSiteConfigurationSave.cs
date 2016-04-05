using System;
using CommonDataSave.Return;
using CommonDataSave.SiteConfiguration;

namespace DataLayerSave.SiteConfiguration
{
    public class DbSiteConfigurationSave
    {
        public ReturnBase SaveSiteConfiguration(SiteConfigurationSave data)
        {
            ReturnBase rb = new ReturnBase();
            try
            {
                using (DbAssessorCompensationSave s = new DbAssessorCompensationSave())
                {
                    rb = s.AddUpdateRecord(data.AssessorCompensation);
                }
                if (rb.ErrMsg.Length != 0)
                {
                    return rb;
                }

                using (DbEmployeeCompensationSave s = new DbEmployeeCompensationSave())
                {
                    rb = s.AddUpdateRecord(data.EmployeeCompensation);
                }
                if (rb.ErrMsg.Length != 0)
                {
                    return rb;
                }

                using (DbGeneralConfigurationSave s = new DbGeneralConfigurationSave())
                {
                    rb = s.AddUpdateRecord(data.GeneralConfiguration);
                }
                if (rb.ErrMsg.Length != 0)
                {
                    return rb;
                }

                using (DbModuleUsageSave s = new DbModuleUsageSave())
                {
                    rb = s.AddUpdateRecord(data.ModuleUsage);
                }
                if (rb.ErrMsg.Length != 0)
                {
                    return rb;
                }

                using (DbPasswordRequirementSave s = new DbPasswordRequirementSave())
                {
                    rb = s.AddUpdateRecord(data.PasswordRequirements);
                }
                if (rb.ErrMsg.Length != 0)
                {
                    return rb;
                }

                using (DbStudyDefinitionsSave s = new DbStudyDefinitionsSave())
                {
                    rb = s.AddUpdateRecord(data.StudyDefinitions);
                }
            }
            catch (Exception ex)
            {
                rb.ErrMsg = ex.Message;
            }
            return rb;
        }
    }
}