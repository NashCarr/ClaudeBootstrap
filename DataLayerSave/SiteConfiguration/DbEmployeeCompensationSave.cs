using System;
using System.Data;
using DataLayerCommon.SiteConfiguration;
using DataLayerSaveCommon;
using SaveDataCommon.Return;

namespace DataLayerSave.SiteConfiguration
{
    public class DbEmployeeCompensationSave : DbSaveBase
    {
        public ReturnBase AddUpdateRecord(EmployeeCompensation data)
        {
            try
            {
                ReturnValues.Id = 1;
                IdParameter = "@EmployeeCompensationId";

                SetConnectToDatabase("[Settings].[usp_EmployeeCompensation_Update]");

                CmdSql.Parameters.Add(IdParameter, SqlDbType.Int).Value = 1;
                CmdSql.Parameters.Add("@UseCompensation", SqlDbType.Bit).Value = data.UseCompensation;
                CmdSql.Parameters.Add("@CompensationType", SqlDbType.TinyInt).Value = data.CompensationType;
                CmdSql.Parameters.Add("@DollarsPerPoint", SqlDbType.Money).Value = data.DollarsPerPoint;
                CmdSql.Parameters.Add("@RedeemPointsMultiples", SqlDbType.SmallInt).Value = data.RedeemPointsMultiples;
                CmdSql.Parameters.Add("@StudyCompensationType", SqlDbType.TinyInt).Value = data.StudyCompensationType;
                CmdSql.Parameters.Add("@StudyAmount", SqlDbType.SmallInt).Value = data.StudyAmount;

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