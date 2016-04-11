using System;
using System.Data;
using CommonDataReturn;

namespace DataLayerDelete.Administration
{
    public class DbTestTypeDelete : DbDeleteBase
    {
        public ReturnBase SetInactive(int id)
        {
            ReturnValues.Id = id;
            try
            {
                SetConnectToDatabase("[TestType].[usp_SetInactive]");

                CmdSql.Parameters.Add("@TestTypeId", SqlDbType.Int).Value = ReturnValues.Id;

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