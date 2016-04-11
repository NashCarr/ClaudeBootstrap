using System;
using System.Data;
using CommonDataReturn;
using CommonDataSave.Assessor;

namespace DataLayerSave.Assessor
{
    public class DbTrainedPanelSave : DbSaveBase
    {
        public ReturnBase AddUpdateRecord(TrainedPanelSave data)
        {
            if (!string.IsNullOrEmpty(data.Name)) return SaveRecord(data);

            SetEmptyStringMessage("Trained Panel");
            return ReturnValues;
        }

        private ReturnBase SaveRecord(TrainedPanelSave data)
        {
            try
            {
                IdParameter = "@TrainedPanelId";
                ReturnValues.Id = data.Id;

                SetConnectToDatabase("[TrainedPanel].[usp_Upsert]");

                SetIdInputOutputParameter();

                CmdSql.Parameters.Add("@Name", SqlDbType.NVarChar, 50).Value = data.Name.Trim();
                CmdSql.Parameters.Add("@FacilityId", SqlDbType.Int).Value = data.FacilityId;
                CmdSql.Parameters.Add("@ExcludeFromConsumerTesting", SqlDbType.Bit).Value =
                    data.ExcludeFromConsumerTesting;

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