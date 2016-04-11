using System;
using System.Data;
using CommonDataReturn;

namespace DataLayerDelete.Administration
{
    public class DbProductGroupDelete : DbDeleteBase
    {
        public ReturnBase SetInactive(int id)
        {
            ReturnValues.Id = id;
            try
            {
                SetConnectToDatabase("[ProductGroup].[usp_SetInactive]");

                CmdSql.Parameters.Add("@ProductGroupId", SqlDbType.Int).Value = ReturnValues.Id;

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