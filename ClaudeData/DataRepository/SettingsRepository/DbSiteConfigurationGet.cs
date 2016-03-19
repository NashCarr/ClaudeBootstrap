using System;
using System.Data.SqlClient;
using ClaudeData.Models.SiteConfiguration;

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

                            //General

                            int ordOneStudy = dr.GetOrdinal("OneStudy");
                            int ordGeneralId = dr.GetOrdinal("GeneralId");
                            int ordLimitIrs1099 = dr.GetOrdinal("LimitIRS1099");
                            int ordIrs1099MaxAmount = dr.GetOrdinal("IRS1099MaxAmount");
                            int ordNoShowSuspendDays = dr.GetOrdinal("NoShowSuspendDay");
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
                                data.General.GeneralId = Convert.ToInt32(dr[ordGeneralId]);
                                data.General.OneStudy = Convert.ToBoolean(dr[ordOneStudy]);
                                data.General.LimitIrs1099 = Convert.ToBoolean(dr[ordLimitIrs1099]);
                                data.General.Irs1099MaxAmount = Convert.ToDecimal(dr[ordIrs1099MaxAmount]);
                                data.General.NoShowSuspendDays = Convert.ToInt16(dr[ordNoShowSuspendDays]);
                                data.General.NoShowSuspendCount = Convert.ToInt16(dr[ordNoShowSuspendCount]);
                                data.General.NewFundOrgStaffEmail = Convert.ToString(dr[ordNewFundOrgStaffEmail]);
                                data.General.PastParticipationDays = Convert.ToInt16(dr[ordPastParticipationDays]);
                                data.General.UsePregnancyQuestion = Convert.ToBoolean(dr[ordUsePregnancyQuestion]);
                                data.General.UnmarkedClosingStatus = Convert.ToInt16(dr[ordUnmarkedClosingStatus]);
                                data.General.OneStudyPerHousehold = Convert.ToBoolean(dr[ordOneStudyPerHousehold]);
                                data.General.TrainedPanelStaffEmail = Convert.ToString(dr[ordTrainedPanelStaffEmail]);
                                data.General.DaysBetweenEmailsToAssessor =
                                    Convert.ToInt16(dr[ordDaysBetweenEmailsToAssessor]);
                                data.General.ClaudeUnmarkedClosingStatus =
                                    Convert.ToInt16(dr[ordClaudeUnmarkedClosingStatus]);
                            }

                            //Modules
                            dr.NextResult();

                            if (dr.HasRows)
                            {
                                int ordModulesId = dr.GetOrdinal("ModulesId");
                                int ordUseFundraising = dr.GetOrdinal("UseFundraising");
                                int ordUseStudyCosting = dr.GetOrdinal("UseStudyCosting");
                                int ordAllowCustomEmail = dr.GetOrdinal("AllowCustomEmail");
                                int ordUseSensoryStudies = dr.GetOrdinal("UseSensoryStudies");
                                int ordUseProjectRequestForms = dr.GetOrdinal("UseProjectRequestForms");
                                int ordUseFacilitiesUtilization = dr.GetOrdinal("UseFacilitiesUtilization");

                                while (dr.Read())
                                {
                                    data.Modules.ModulesId = Convert.ToInt32(dr[ordModulesId]);
                                    data.Modules.UseFundRaising = Convert.ToBoolean(dr[ordUseFundraising]);
                                    data.Modules.UseStudyCosting = Convert.ToBoolean(dr[ordUseStudyCosting]);
                                    data.Modules.AllowCustomEmail = Convert.ToBoolean(dr[ordAllowCustomEmail]);
                                    data.Modules.UseSensoryStudies = Convert.ToBoolean(dr[ordUseSensoryStudies]);
                                    data.Modules.UseProjectRequestForms =
                                        Convert.ToBoolean(dr[ordUseProjectRequestForms]);
                                    data.Modules.UseFacilitiesUtilization =
                                        Convert.ToBoolean(dr[ordUseFacilitiesUtilization]);
                                }
                            }

                            //AssessorCompensation
                            dr.NextResult();

                            if (dr.HasRows)
                            {
                                int ordCompType = dr.GetOrdinal("CompType");
                                int ordStudyAmount = dr.GetOrdinal("StudyAmount");
                                int ordStudyCompType = dr.GetOrdinal("StudyCompType");
                                int ordAssessorCompId = dr.GetOrdinal("AssessorCompId");
                                int ordUseCompensation = dr.GetOrdinal("UseCompensation");
                                int ordDollarsPerPoint = dr.GetOrdinal("DollarsPerPoint");
                                int ordRedeemPointsMultiples = dr.GetOrdinal("RedeemPointsMultiples");

                                int ordReferralAmount = dr.GetOrdinal("ReferralAmount");
                                int ordReferralCompType = dr.GetOrdinal("ReferralCompType");
                                int ordRegistrationAmount = dr.GetOrdinal("RegistrationAmount");
                                int ordOrganizationAmount = dr.GetOrdinal("OrganizationAmount");
                                int ordRegistrationCompType = dr.GetOrdinal("RegistrationCompType");
                                int ordOrganizationCompType = dr.GetOrdinal("OrganizationCompType");

                                while (dr.Read())
                                {
                                    data.AssessorComp.CompensationType = Convert.ToInt16(dr[ordCompType]);
                                    data.AssessorComp.StudyAmount = Convert.ToDecimal(dr[ordStudyAmount]);
                                    data.AssessorComp.UseCompensation = Convert.ToBoolean(dr[ordUseCompensation]);
                                    data.AssessorComp.DollarsPerPoint = Convert.ToDecimal(dr[ordDollarsPerPoint]);
                                    data.AssessorComp.StudyCompensationType = Convert.ToInt16(dr[ordStudyCompType]);
                                    data.AssessorComp.AssessorCompensationId = Convert.ToInt32(dr[ordAssessorCompId]);
                                    data.AssessorComp.RedeemPointsMultiples =
                                        Convert.ToInt16(dr[ordRedeemPointsMultiples]);

                                    data.AssessorComp.ReferralAmount = Convert.ToDecimal(dr[ordReferralAmount]);
                                    data.AssessorComp.RegistrationAmount = Convert.ToDecimal(dr[ordRegistrationAmount]);
                                    data.AssessorComp.OrganizationAmount = Convert.ToDecimal(dr[ordOrganizationAmount]);
                                    data.AssessorComp.ReferralCompensationType = Convert.ToInt16(dr[ordReferralCompType]);
                                    data.AssessorComp.ReferralCompensationType =
                                        Convert.ToInt16(dr[ordRegistrationCompType]);
                                    data.AssessorComp.OrganizationCompensationType =
                                        Convert.ToInt16(dr[ordOrganizationCompType]);
                                }
                            }

                            //EmployeeCompensation
                            dr.NextResult();

                            if (dr.HasRows)
                            {
                                int ordCompType = dr.GetOrdinal("CompType");
                                int ordStudyAmount = dr.GetOrdinal("StudyAmount");
                                int ordStudyCompType = dr.GetOrdinal("StudyCompType");
                                int ordEmployeeCompId = dr.GetOrdinal("EmployeeCompId");
                                int ordUseCompensation = dr.GetOrdinal("UseCompensation");
                                int ordDollarsPerPoint = dr.GetOrdinal("DollarsPerPoint");
                                int ordRedeemPointsMultiples = dr.GetOrdinal("RedeemPointsMultiples");

                                while (dr.Read())
                                {
                                    data.EmployeeComp.CompensationType = Convert.ToInt16(dr[ordCompType]);
                                    data.EmployeeComp.StudyAmount = Convert.ToDecimal(dr[ordStudyAmount]);
                                    data.EmployeeComp.UseCompensation = Convert.ToBoolean(dr[ordUseCompensation]);
                                    data.EmployeeComp.DollarsPerPoint = Convert.ToDecimal(dr[ordDollarsPerPoint]);
                                    data.EmployeeComp.StudyCompensationType = Convert.ToInt16(dr[ordStudyCompType]);
                                    data.EmployeeComp.EmployeeCompensationId = Convert.ToInt32(dr[ordEmployeeCompId]);
                                    data.EmployeeComp.RedeemPointsMultiples =
                                        Convert.ToInt16(dr[ordRedeemPointsMultiples]);
                                }
                            }

                            //Study Definition
                            dr.NextResult();

                            if (dr.HasRows)
                            {
                                int ordBudget = dr.GetOrdinal("Budget");
                                int ordOverview = dr.GetOrdinal("Overview");
                                int ordFoodRequirements = dr.GetOrdinal("FoodReqs");
                                int ordOtherRequirements = dr.GetOrdinal("OtherReqs");
                                int ordCustomerBrands = dr.GetOrdinal("CustomerBrands");
                                int ordExternalSpending = dr.GetOrdinal("ExternalSpending");
                                int ordCustomerContacts = dr.GetOrdinal("CustomerContacts");
                                int ordResearchObjective = dr.GetOrdinal("ResearchObjective");
                                int ordScreeningCriteria = dr.GetOrdinal("ScreeningCriteria");
                                int ordStudyDefinitionId = dr.GetOrdinal("StudyDefinitionId");
                                int ordContractorRequirements = dr.GetOrdinal("ContractorReqs");
                                int ordAudioVisualRequirements = dr.GetOrdinal("AudioVisualReqs");

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
                                    data.Passwords.MinimumLength = Convert.ToInt32(dr[ordMinimumLength]);
                                    data.Passwords.RequireNumber = Convert.ToBoolean(dr[ordRequireNumber]);
                                    data.Passwords.ExpirationDays = Convert.ToInt32(dr[ordExpirationDays]);
                                    data.Passwords.RequireMinimumLength = Convert.ToBoolean(dr[ordRequireMinimumLength]);
                                    data.Passwords.RequireCapitalLetter = Convert.ToBoolean(dr[ordRequireCapitalLetter]);
                                    data.Passwords.PasswordRequirementId = Convert.ToInt32(dr[ordPasswordRequirementId]);
                                    data.Passwords.RequireSpecialCharacter =
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