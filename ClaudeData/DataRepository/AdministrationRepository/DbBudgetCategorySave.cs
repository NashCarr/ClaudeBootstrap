using System;
using System.Data;
using ClaudeCommon.BaseModels.Returns;
using ClaudeCommon.Models.Administration;

namespace ClaudeData.DataRepository.AdministrationRepository
{
    public class DbBudgetCategorySave : DbSaveBase
    {
        public ReturnBase SetInactive(int recordId)
        {
            ReturnValues.Id = recordId;
            try
            {
                SetConnectToDatabase("[Admin].[usp_BudgetCategory_SetInactive]");

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

        public ReturnBase AddUpdateRecord(BudgetCategory data)
        {
            ReturnValues.Id = data.RecordId;

            if (!string.IsNullOrEmpty(data.Name)) return SaveRecord(data);

            SetEmptyStringMessage("Budget Category");
            return ReturnValues;
        }

        private ReturnBase SaveRecord(BudgetCategory data)
        {
            try
            {
                IdParameter = "@BudgetCategoryId";

                SetConnectToDatabase("[Admin].[usp_BudgetCategory_Upsert]");

                SetIdInputOutputParameter();

                CmdSql.Parameters.Add("@Name", SqlDbType.NVarChar, 50).Value = data.Name.Trim();
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