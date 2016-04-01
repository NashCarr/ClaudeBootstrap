using System;
using System.Data;
using CommonData.BaseModels.Returns;
using CommonData.Models.SiteConfiguration;

namespace DataManagement.DataRepository.SiteConfiguration
{
    public class DbGeneralConfigurationSave : DbSaveBase
    {
        public ReturnBase AddUpdateRecord(GeneralConfiguration data)
        {
            try
            {
                ReturnValues.Id = 1;
                IdParameter = "@GeneralConfigurationId";

                SetConnectToDatabase("[Settings].[usp_GeneralConfiguration_Update]");

                CmdSql.Parameters.Add(IdParameter, SqlDbType.Int).Value = 1;
                CmdSql.Parameters.Add("@PastParticipationDays", SqlDbType.TinyInt).Value = data.PastParticipationDays;
                CmdSql.Parameters.Add("@LimitIRS1099", SqlDbType.Bit).Value = data.LimitIrs1099;
                CmdSql.Parameters.Add("@IRS1099MaxAmount", SqlDbType.Money).Value = data.Irs1099MaxAmount;
                CmdSql.Parameters.Add("@OneStudy", SqlDbType.Bit).Value = data.OneStudy;
                CmdSql.Parameters.Add("@OneStudyPerHousehold", SqlDbType.Bit).Value = data.OneStudyPerHousehold;
                CmdSql.Parameters.Add("@UsePregnancyQuestion", SqlDbType.Bit).Value = data.UsePregnancyQuestion;
                CmdSql.Parameters.Add("@DaysBetweenEmailsToAssessor", SqlDbType.TinyInt).Value =
                    data.DaysBetweenEmailsToAssessor;
                CmdSql.Parameters.Add("@NewFundOrgStaffEmail", SqlDbType.NVarChar, 50).Value = data.NewFundOrgStaffEmail;
                CmdSql.Parameters.Add("@TrainedPanelStaffEmail", SqlDbType.NVarChar, 50).Value =
                    data.TrainedPanelStaffEmail;
                CmdSql.Parameters.Add("@NoShowSuspendDays", SqlDbType.SmallInt).Value = data.NoShowSuspendDays;
                CmdSql.Parameters.Add("@NoShowSuspendCount", SqlDbType.SmallInt).Value = data.NoShowSuspendCount;
                CmdSql.Parameters.Add("@ClaudeUnmarkedClosingStatus", SqlDbType.TinyInt).Value =
                    data.ClaudeUnmarkedClosingStatus;
                CmdSql.Parameters.Add("@UnmarkedClosingStatus", SqlDbType.TinyInt).Value = data.UnmarkedClosingStatus;

                SetErrMsgParameter();

                SendNonQueryGetId();
            }
            catch (Exception ex)
            {
                ReturnValues.ErrMsg = ex.Message;
            }
            return ReturnValues;
        }
    }
}