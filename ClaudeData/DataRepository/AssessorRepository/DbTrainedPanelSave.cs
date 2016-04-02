using System;
using System.Data;
using CommonData.Models.Assessor;
using DataSaveLayer;
using SaveDataCommon;

namespace DataManagement.DataRepository.AssessorRepository
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

        public ReturnBase AddUpdateRecord(TrainedPanel data)
        {
            if (!string.IsNullOrEmpty(data.Name)) return SaveRecord(data);

            SetEmptyStringMessage("Budget Category");
            return ReturnValues;
        }

        private ReturnBase SaveRecord(TrainedPanel data)
        {
            try
            {
                IdParameter = "@TrainedPanelId";
                ReturnValues.Id = data.RecordId;

                SetConnectToDatabase("[TrainedPanel].[usp_Upsert]");

                SetIdInputOutputParameter();

                CmdSql.Parameters.Add("@Name", SqlDbType.NVarChar, 50).Value = data.Name.Trim();
                CmdSql.Parameters.Add("@FacilityId", SqlDbType.Int).Value = data.FacilityId;
                CmdSql.Parameters.Add("@ExcludeFromConsumerTesting", SqlDbType.Bit).Value =
                    data.ExcludeFromConsumerTesting;
                CmdSql.Parameters.Add("@DisplayOrder", SqlDbType.Int).Value = data.DisplayOrder;

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