﻿using System;
using System.Data;
using CommonData.BaseModels.Returns;
using CommonData.Models.Administration;

namespace DataSaveLayer.Administration
{
    public class DbBudgetCategorySave : DbSaveBase
    {
        public ReturnBase SetInactive(int recordId)
        {
            ReturnValues.Id = recordId;
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

                SetConnectToDatabase("[BudgetCategory].[usp_Upsert]");

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