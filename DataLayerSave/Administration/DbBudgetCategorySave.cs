using System;
using System.Data;
using DataLayerSaveCommon;
using SaveDataCommon;

namespace DataLayerSave.Administration
{
    public class DbBudgetCategorySave : DbSaveBase
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

        public ReturnBase AddUpdateRecord(SaveBase data)
        {
            ReturnValues.Id = data.Id;

            if (!string.IsNullOrEmpty(data.Name)) return SaveRecord(data);

            SetEmptyStringMessage("Budget Category");
            return ReturnValues;
        }

        private ReturnBase SaveRecord(SaveBase data)
        {
            try
            {
                IdParameter = "@BudgetCategoryId";

                SetConnectToDatabase("[BudgetCategory].[usp_Upsert]");

                SetIdInputOutputParameter();

                CmdSql.Parameters.Add("@Name", SqlDbType.NVarChar, 50).Value = data.Name.Trim();

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