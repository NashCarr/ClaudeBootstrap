using System;
using System.Data;
using CommonDataReturn;

namespace DataLayerDelete.Assessor
{
    public class DbTrainedPanelDelete : DbDeleteBase
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
    }
}