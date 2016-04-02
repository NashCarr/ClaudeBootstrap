using System;
using System.Data;
using SaveDataCommon;

namespace DataSaveLayer.Administration
{
    public class DbGiftCardSave : DbSaveBase
    {
        public ReturnBase SetInactive(int id)
        {
            ReturnValues.Id = id;
            try
            {
                SetConnectToDatabase("[GiftCard].[usp_SetInactive]");

                CmdSql.Parameters.Add("@GiftCardId", SqlDbType.Int).Value = ReturnValues.Id;

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

            SetEmptyStringMessage("Gift Card");
            return ReturnValues;
        }

        private ReturnBase SaveRecord(SaveBase data)
        {
            try
            {
                IdParameter = "@GiftCardId";

                SetConnectToDatabase("[GiftCard].[usp_Upsert]");

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