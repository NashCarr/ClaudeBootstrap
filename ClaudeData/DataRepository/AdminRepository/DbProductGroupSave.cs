using System;
using System.Data;
using ClaudeData.Models.Admin;

namespace ClaudeData.DataRepository.AdminRepository
{
    public class DbProductGroupSave : DbSaveBase
    {
        public string AddUpdateRecord(ProductGroup data)
        {
            if (string.IsNullOrEmpty(data.Name))
            {
                SetEmptyStringMessage("Product Group");
                return ReturnValues.ErrMsg;
            }

            try
            {
                ReturnValues.Id = data.RecordId;
                IdParameter = "@ProductGroupId";

                SetConnectToDatabase("[Admin].[usp_ProductGroup_Upsert]");

                SetIdInputOutputParameter();

                CmdSql.Parameters.Add("@Name", SqlDbType.NVarChar, 50).Value = data.Name.Trim();
                CmdSql.Parameters.Add("@DisplayOrder", SqlDbType.Int).Value = data.DisplayOrder;
                CmdSql.Parameters.Add("@IsSystem", SqlDbType.Bit).Value = data.IsSystem;
                CmdSql.Parameters.Add("@IsActive", SqlDbType.Bit).Value = data.IsActive;

                SetErrMsgParameter();

                SendNonQueryGetId();
            }
            catch (Exception ex)
            {
                ReturnValues.ErrMsg = ex.Message;
            }
            return ReturnValues.ErrMsg;
        }

        public string SetInactive(int productGroupId)
        {
            try
            {
                SetConnectToDatabase("[Admin].[usp_ProductGroup_SetInactive]");

                CmdSql.Parameters.Add("@ProductGroupId", SqlDbType.Int).Value = productGroupId;

                SetErrMsgParameter();

                SendNonQuery();
            }
            catch (Exception ex)
            {
                ReturnValues.ErrMsg = ex.Message;
            }
            return ReturnValues.ErrMsg;
        }
    }
}