using System;
using System.Data;
using CommonDataReturn;

namespace DataLayerDelete.Customer
{
    public class DbCustomerBrandDelete : DbDeleteBase
    {
        public ReturnBase SetInactive(int recordId)
        {
            ReturnValues.Id = recordId;
            try
            {
                SetConnectToDatabase("[CustomerBrand].[usp_SetInactive]");

                CmdSql.Parameters.Add("@CustomerBrandId", SqlDbType.Int).Value = ReturnValues.Id;

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