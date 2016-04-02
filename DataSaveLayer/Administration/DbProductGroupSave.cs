using System;
using System.Data;
using CommonData.BaseModels.Returns;
using CommonData.Models.Administration;

namespace DataSaveLayer.Administration
{
    public class DbProductGroupSave : DbSaveBase
    {
        public ReturnBase SetInactive(int recordId)
        {
            ReturnValues.Id = recordId;
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

        public ReturnBase AddUpdateRecord(ProductGroup data)
        {
            ReturnValues.Id = data.RecordId;

            if (!string.IsNullOrEmpty(data.Name)) return SaveRecord(data);

            SetEmptyStringMessage("Product Group");
            return ReturnValues;
        }

        private ReturnBase SaveRecord(ProductGroup data)
        {
            try
            {
                IdParameter = "@ProductGroupId";

                SetConnectToDatabase("[ProductGroup].[usp_Upsert]");

                SetIdInputOutputParameter();

                CmdSql.Parameters.Add("@Name", SqlDbType.NVarChar, 50).Value = data.Name.Trim();
                CmdSql.Parameters.Add("@DisplayOrder", SqlDbType.Int).Value = data.DisplayOrder;
                CmdSql.Parameters.Add("@IsSystem", SqlDbType.Bit).Value = data.IsSystem;

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