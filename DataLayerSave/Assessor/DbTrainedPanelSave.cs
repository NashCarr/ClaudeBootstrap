using System;
using System.Data;
using DataLayerSaveCommon;
using SaveDataCommon.Assessor;
using SaveDataCommon.Return;

namespace DataLayerSave.Assessor
{
    public class DbTrainedPanelSave : DbSaveBase
    {
        public ReturnBase SetInactive(int recordId)
        {
            ReturnValues.Id = recordId;
            try
            {
                SetConnectToDatabase("[TrainedPanel].[usp_SetInactive]");

                CmdSql.Parameters.Add("@TrainedPanelId", SqlDbType.Int).Value = ReturnValues.Id;

                SetErrMsgParameter();

                SendNonQuery();
            }
            catch (Exception ex)
            {
                ReturnValues.ErrMsg = ex.Message;
            }

            return ReturnValues;
        }

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