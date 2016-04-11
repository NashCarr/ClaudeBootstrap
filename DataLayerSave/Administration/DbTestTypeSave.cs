using System;
using System.Data;
using CommonDataReturn;
using CommonDataSave.Administration;

namespace DataLayerSave.Administration
{
    public class DbTestTypeSave : DbSaveBase
    {
        public ReturnBase AddUpdateRecord(TestTypeSave data)
        {
            ReturnValues.Id = data.Id;

            if (!string.IsNullOrEmpty(data.Name)) return SaveRecord(data);

            SetEmptyStringMessage("Study Design");
            return ReturnValues;
        }

        private ReturnBase SaveRecord(TestTypeSave data)
        {
            try
            {
                IdParameter = "@TestTypeId";

                SetConnectToDatabase("[TestType].[usp_Upsert]");

                SetIdInputOutputParameter();

                CmdSql.Parameters.Add("@Name", SqlDbType.NVarChar, 50).Value = data.Name.Trim();
                CmdSql.Parameters.Add("@Radius", SqlDbType.Int).Value = data.Radius;

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