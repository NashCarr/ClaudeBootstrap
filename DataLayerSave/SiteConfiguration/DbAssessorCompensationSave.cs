using System;
using System.Data;
using CommonData.Models.SiteConfiguration;
using DataLayerSaveCommon;
using SaveDataCommon;

namespace DataLayerSave.SiteConfiguration
{
    public class DbAssessorCompensationSave : DbSaveBase
    {
        public ReturnBase AddUpdateRecord(AssessorCompensation data)
        {
            try
            {
                ReturnValues.Id = 1;
                IdParameter = "@AssessorCompensationId";

                SetConnectToDatabase("[Settings].[usp_AssessorCompensation_Update]");

                CmdSql.Parameters.Add(IdParameter, SqlDbType.Int).Value = 1;
                CmdSql.Parameters.Add("@UseCompensation", SqlDbType.Bit).Value = data.UseCompensation;
                CmdSql.Parameters.Add("@CompensationType", SqlDbType.TinyInt).Value = data.CompensationType;
                CmdSql.Parameters.Add("@DollarsPerPoint", SqlDbType.Money).Value = data.DollarsPerPoint;
                CmdSql.Parameters.Add("@RedeemPointsMultiples", SqlDbType.SmallInt).Value = data.RedeemPointsMultiples;
                CmdSql.Parameters.Add("@StudyCompensationType", SqlDbType.TinyInt).Value = data.StudyCompensationType;
                CmdSql.Parameters.Add("@StudyAmount", SqlDbType.SmallInt).Value = data.StudyAmount;
                CmdSql.Parameters.Add("@RegistrationCompensationType", SqlDbType.TinyInt).Value =
                    data.RegistrationCompensationType;
                CmdSql.Parameters.Add("@RegistrationAmount", SqlDbType.SmallInt).Value = data.RegistrationAmount;
                CmdSql.Parameters.Add("@ReferralCompensationType", SqlDbType.TinyInt).Value =
                    data.ReferralCompensationType;
                CmdSql.Parameters.Add("@ReferralAmount", SqlDbType.SmallInt).Value = data.ReferralAmount;
                CmdSql.Parameters.Add("@OrganizationCompensationType", SqlDbType.TinyInt).Value =
                    data.OrganizationCompensationType;
                CmdSql.Parameters.Add("@OrganizationAmount", SqlDbType.SmallInt).Value = data.OrganizationAmount;

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