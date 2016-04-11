using System;
using System.Data;
using CommonDataReturn;

namespace DataLayerDelete.Administration
{
    public class DbBudgetCategoryDelete : DbDeleteBase
    {
        public ReturnBase SetInactive(int id)
        {
            ReturnValues.Id = id;
            try
            {
                SetConnectToDatabase("[BudgetCategory].[usp_SetInactive]");

                CmdSql.Parameters.Add("@BudgetCategoryId", SqlDbType.Int).Value = ReturnValues.Id;

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