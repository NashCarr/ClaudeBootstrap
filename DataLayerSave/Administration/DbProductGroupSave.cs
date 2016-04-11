using System;
using System.Data;
using CommonDataReturn;
using CommonDataSave;

namespace DataLayerSave.Administration
{
    public class DbProductGroupSave : DbSaveBase
    {
        public ReturnBase AddUpdateRecord(SaveBase data)
        {
            ReturnValues.Id = data.Id;

            if (!string.IsNullOrEmpty(data.Name)) return SaveRecord(data);

            SetEmptyStringMessage("Product Group");
            return ReturnValues;
        }

        private ReturnBase SaveRecord(SaveBase data)
        {
            try
            {
                IdParameter = "@ProductGroupId";

                SetConnectToDatabase("[ProductGroup].[usp_Upsert]");

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