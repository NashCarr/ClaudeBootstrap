using System;
using System.Data.SqlClient;
using ClaudeCommon.Models.SiteConfiguration;

namespace ClaudeData.DataRepository.SettingsRepository
{
    public class DbSiteConfigurationGet : DbGetBase
    {
        public SiteConfiguration GetSiteConfiguration()
        {
            return LoadRecords();
        }

        private SiteConfiguration LoadRecords()
        {
            SiteConfiguration data = new SiteConfiguration();
            try
            {
                SetConnectToDatabase("[Settings].[usp_SiteConfiguration_GetData]");

                using (ConnSql)
                {
                    ConnSql.Open();
                    using (CmdSql)
                    {
                        using (SqlDataReader dr = CmdSql.ExecuteReader())
                        {
                            if (!dr.HasRows)
                            {
                                return data;
                            }

                            int ordStudyAmount;
                            int ordUseCompensation;
                            int ordDollarsPerPoint;
                            int ordCompensationType;
                            int ordRedeemPointsMultiples;
                            int ordStudyCompensationType;

                            //GeneralConfiguration
                            int ordOneStudy = dr.GetOrdinal("OneStudy");
                            int ordLimitIrs1099 = dr.GetOrdinal("LimitIRS1099");
                            int ordIrs1099MaxAmount = dr.GetOrdinal("IRS1099MaxAmount");
                            int ordNoShowSuspendDays = dr.GetOrdinal("NoShowSuspendDays");
                            int ordNoShowSuspendCount = dr.GetOrdinal("NoShowSuspendCount");
                            int ordOneStudyPerHousehold = dr.GetOrdinal("OneStudyPerHousehold");
                            int ordUsePregnancyQuestion = dr.GetOrdinal("UsePregnancyQuestion");
                            int ordNewFundOrgStaffEmail = dr.GetOrdinal("NewFundOrgStaffEmail");
                            int ordPastParticipationDays = dr.GetOrdinal("PastParticipationDays");
                            int ordUnmarkedClosingStatus = dr.GetOrdinal("UnmarkedClosingStatus");
                            int ordTrainedPanelStaffEmail = dr.GetOrdinal("TrainedPanelStaffEmail");
                            int ordClaudeUnmarkedClosingStatus = dr.GetOrdinal("ClaudeUnmarkedClosingStatus");
                            int ordDaysBetweenEmailsToAssessor = dr.GetOrdinal("DaysBetweenEmailsToAssessor");

                            while (dr.Read())
                            {
                                data.GeneralConfiguration.GeneralConfigurationId = 1;
                                data.GeneralConfiguration.OneStudy = Convert.ToBoolean(dr[ordOneStudy]);
                                data.GeneralConfiguration.LimitIrs1099 = Convert.ToBoolean(dr[ordLimitIrs1099]);
                                data.GeneralConfiguration.Irs1099MaxAmount = Convert.ToDecimal(dr[ordIrs1099MaxAmount]);
                                data.GeneralConfiguration.NoShowSuspendDays = Convert.ToInt16(dr[ordNoShowSuspendDays]);
                                data.GeneralConfiguration.NoShowSuspendCount = Convert.ToInt16(dr[ordNoShowSuspendCount]);
                                data.GeneralConfiguration.NewFundOrgStaffEmail =
                                    Convert.ToString(dr[ordNewFundOrgStaffEmail]);
                                data.GeneralConfiguration.PastParticipationDays =
                                    Convert.ToInt16(dr[ordPastParticipationDays]);
                                data.GeneralConfiguration.UsePregnancyQuestion =
                                    Convert.ToBoolean(dr[ordUsePregnancyQuestion]);
                                data.GeneralConfiguration.UnmarkedClosingStatus =
                                    Convert.ToInt16(dr[ordUnmarkedClosingStatus]);
                                data.GeneralConfiguration.OneStudyPerHousehold =
                                    Convert.ToBoolean(dr[ordOneStudyPerHousehold]);
                                data.GeneralConfiguration.TrainedPanelStaffEmail =
                                    Convert.ToString(dr[ordTrainedPanelStaffEmail]);
                                data.GeneralConfiguration.DaysBetweenEmailsToAssessor =
                                    Convert.ToInt16(dr[ordDaysBetweenEmailsToAssessor]);
                                data.GeneralConfiguration.ClaudeUnmarkedClosingStatus =
                                    Convert.ToInt16(dr[ordClaudeUnmarkedClosingStatus]);
                            }

                            //ModuleUsage
                            dr.NextResult();

                            if (dr.HasRows)
                            {
                                int ordModuleUsageId = dr.GetOrdinal("ModuleUsageId");
                                int ordUseFundraising = dr.GetOrdinal("UseFundraising");
                                int ordUseStudyCosting = dr.GetOrdinal("UseStudyCosting");
                                int ordAllowCustomEmail = dr.GetOrdinal("AllowCustomEmail");
                                int ordUseSensoryStudies = dr.GetOrdinal("UseSensoryStudies");
                                int ordUseProjectRequestForms = dr.GetOrdinal("UseProjectRequestForms");
                                int ordUseFacilitiesUtilization = dr.GetOrdinal("UseFacilitiesUtilization");

                                while (dr.Read())
                                {
                                    data.ModuleUsage.ModuleUsageId = Convert.ToInt32(dr[ordModuleUsageId]);
                                    data.ModuleUsage.UseFundRaising = Convert.ToBoolean(dr[ordUseFundraising]);
                                    data.ModuleUsage.UseStudyCosting = Convert.ToBoolean(dr[ordUseStudyCosting]);
                                    data.ModuleUsage.AllowCustomEmail = Convert.ToBoolean(dr[ordAllowCustomEmail]);
                                    data.ModuleUsage.UseSensoryStudies = Convert.ToBoolean(dr[ordUseSensoryStudies]);
                                    data.ModuleUsage.UseProjectRequestForms =
                                        Convert.ToBoolean(dr[ordUseProjectRequestForms]);
                                    data.ModuleUsage.UseFacilitiesUtilization =
                                        Convert.ToBoolean(dr[ordUseFacilitiesUtilization]);
                                }
                            }

                            //AssessorCompensation
                            dr.NextResult();

                            if (dr.HasRows)
                            {
                                ordStudyAmount = dr.GetOrdinal("StudyAmount");
                                ordUseCompensation = dr.GetOrdinal("UseCompensation");
                                ordDollarsPerPoint = dr.GetOrdinal("DollarsPerPoint");
                                ordCompensationType = dr.GetOrdinal("CompensationType");
                                ordRedeemPointsMultiples = dr.GetOrdinal("RedeemPointsMultiples");
                                ordStudyCompensationType = dr.GetOrdinal("StudyCompensationType");

                                int ordReferralAmount = dr.GetOrdinal("ReferralAmount");
                                int ordRegistrationAmount = dr.GetOrdinal("RegistrationAmount");
                                int ordOrganizationAmount = dr.GetOrdinal("OrganizationAmount");
                                int ordAssessorCompensationId = dr.GetOrdinal("AssessorCompensationId");
                                int ordReferralCompensationType = dr.GetOrdinal("ReferralCompensationType");
                                int ordRegistrationCompensationType = dr.GetOrdinal("RegistrationCompensationType");
                                int ordOrganizationCompensationType = dr.GetOrdinal("OrganizationCompensationType");

                                while (dr.Read())
                                {
                                    data.AssessorCompensation.StudyAmount = Convert.ToDecimal(dr[ordStudyAmount]);
                                    data.AssessorCompensation.CompensationType = Convert.ToInt16(dr[ordCompensationType]);
                                    data.AssessorCompensation.UseCompensation = Convert.ToBoolean(dr[ordUseCompensation]);
                                    data.AssessorCompensation.DollarsPerPoint = Convert.ToDecimal(dr[ordDollarsPerPoint]);
                                    data.AssessorCompensation.AssessorCompensationId =
                                        Convert.ToInt32(dr[ordAssessorCompensationId]);
                                    data.AssessorCompensation.StudyCompensationType =
                                        Convert.ToInt16(dr[ordStudyCompensationType]);
                                    data.AssessorCompensation.RedeemPointsMultiples =
                                        Convert.ToInt16(dr[ordRedeemPointsMultiples]);

                                    data.AssessorCompensation.ReferralAmount = Convert.ToDecimal(dr[ordReferralAmount]);
                                    data.AssessorCompensation.RegistrationAmount =
                                        Convert.ToDecimal(dr[ordRegistrationAmount]);
                                    data.AssessorCompensation.OrganizationAmount =
                                        Convert.ToDecimal(dr[ordOrganizationAmount]);
                                    data.AssessorCompensation.ReferralCompensationType =
                                        Convert.ToInt16(dr[ordReferralCompensationType]);
                                    data.AssessorCompensation.ReferralCompensationType =
                                        Convert.ToInt16(dr[ordRegistrationCompensationType]);
                                    data.AssessorCompensation.OrganizationCompensationType =
                                        Convert.ToInt16(dr[ordOrganizationCompensationType]);
                                }
                            }

                            //EmployeeCompensation
                            dr.NextResult();

                            if (dr.HasRows)
                            {
                                ordStudyAmount = dr.GetOrdinal("StudyAmount");
                                ordUseCompensation = dr.GetOrdinal("UseCompensation");
                                ordDollarsPerPoint = dr.GetOrdinal("DollarsPerPoint");
                                ordCompensationType = dr.GetOrdinal("CompensationType");
                                ordStudyCompensationType = dr.GetOrdinal("StudyCompensationType");
                                ordRedeemPointsMultiples = dr.GetOrdinal("RedeemPointsMultiples");

                                int ordEmployeeCompensationId = dr.GetOrdinal("EmployeeCompensationId");

                                while (dr.Read())
                                {
                                    data.EmployeeCompensation.StudyAmount = Convert.ToDecimal(dr[ordStudyAmount]);
                                    data.EmployeeCompensation.CompensationType = Convert.ToInt16(dr[ordCompensationType]);
                                    data.EmployeeCompensation.UseCompensation = Convert.ToBoolean(dr[ordUseCompensation]);
                                    data.EmployeeCompensation.DollarsPerPoint = Convert.ToDecimal(dr[ordDollarsPerPoint]);
                                    data.EmployeeCompensation.EmployeeCompensationId =
                                        Convert.ToInt32(dr[ordEmployeeCompensationId]);
                                    data.EmployeeCompensation.StudyCompensationType =
                                        Convert.ToInt16(dr[ordStudyCompensationType]);
                                    data.EmployeeCompensation.RedeemPointsMultiples =
                                        Convert.ToInt16(dr[ordRedeemPointsMultiples]);
                                }
                            }

                            //Study Definition
                            dr.NextResult();

                            if (dr.HasRows)
                            {
                                int ordBudget = dr.GetOrdinal("Budget");
                                int ordOverview = dr.GetOrdinal("Overview");
                                int ordCustomerBrands = dr.GetOrdinal("CustomerBrands");
                                int ordExternalSpending = dr.GetOrdinal("ExternalSpending");
                                int ordCustomerContacts = dr.GetOrdinal("CustomerContacts");
                                int ordFoodRequirements = dr.GetOrdinal("FoodRequirements");
                                int ordOtherRequirements = dr.GetOrdinal("OtherRequirements");
                                int ordResearchObjective = dr.GetOrdinal("ResearchObjective");
                                int ordScreeningCriteria = dr.GetOrdinal("ScreeningCriteria");
                                int ordStudyDefinitionId = dr.GetOrdinal("StudyDefinitionId");
                                int ordContractorRequirements = dr.GetOrdinal("ContractorRequirements");
                                int ordAudioVisualRequirements = dr.GetOrdinal("AudioVisualRequirements");

                                while (dr.Read())
                                {
                                    data.StudyDefinitions.Budget = Convert.ToBoolean(dr[ordBudget]);
                                    data.StudyDefinitions.Overview = Convert.ToBoolean(dr[ordOverview]);
                                    data.StudyDefinitions.CustomerBrands = Convert.ToBoolean(dr[ordCustomerBrands]);
                                    data.StudyDefinitions.StudyDefinitionId = Convert.ToInt32(dr[ordStudyDefinitionId]);
                                    data.StudyDefinitions.CustomerContacts = Convert.ToBoolean(dr[ordCustomerContacts]);
                                    data.StudyDefinitions.ExternalSpending = Convert.ToBoolean(dr[ordExternalSpending]);
                                    data.StudyDefinitions.FoodRequirements = Convert.ToBoolean(dr[ordFoodRequirements]);
                                    data.StudyDefinitions.OtherRequirements = Convert.ToBoolean(dr[ordOtherRequirements]);
                                    data.StudyDefinitions.ResearchObjective = Convert.ToBoolean(dr[ordResearchObjective]);
                                    data.StudyDefinitions.ScreeningCriteria = Convert.ToBoolean(dr[ordScreeningCriteria]);
                                    data.StudyDefinitions.ContractorRequirements =
                                        Convert.ToBoolean(dr[ordContractorRequirements]);
                                    data.StudyDefinitions.AudioVisualRequirements =
                                        Convert.ToBoolean(dr[ordAudioVisualRequirements]);
                                }
                            }

                            //PasswordRequirements
                            dr.NextResult();

                            if (dr.HasRows)
                            {
                                int ordRequireNumber = dr.GetOrdinal("RequireNumber");
                                int ordMinimumLength = dr.GetOrdinal("MinimumLength");
                                int ordExpirationDays = dr.GetOrdinal("ExpirationDays");
                                int ordRequireMinimumLength = dr.GetOrdinal("RequireMinimumLength");
                                int ordRequireCapitalLetter = dr.GetOrdinal("RequireCapitalLetter");
                                int ordPasswordRequirementId = dr.GetOrdinal("PasswordRequirementId");
                                int ordRequireSpecialCharacter = dr.GetOrdinal("RequireSpecialCharacter");

                                while (dr.Read())
                                {
                                    data.PasswordRequirements.MinimumLength = Convert.ToInt32(dr[ordMinimumLength]);
                                    data.PasswordRequirements.RequireNumber = Convert.ToBoolean(dr[ordRequireNumber]);
                                    data.PasswordRequirements.ExpirationDays = Convert.ToInt32(dr[ordExpirationDays]);
                                    data.PasswordRequirements.RequireMinimumLength = Convert.ToBoolean(dr[ordRequireMinimumLength]);
                                    data.PasswordRequirements.RequireCapitalLetter = Convert.ToBoolean(dr[ordRequireCapitalLetter]);
                                    data.PasswordRequirements.PasswordRequirementId = Convert.ToInt32(dr[ordPasswordRequirementId]);
                                    data.PasswordRequirements.RequireSpecialCharacter =
                                        Convert.ToBoolean(dr[ordRequireSpecialCharacter]);
                                }
                            }
                        }
                    }
                    ConnSql.Close();
                }
            }
            catch (Exception ex)
            {
                DocumentErrorMessage(ex.ToString());
            }
            return data;
        }
    }
}