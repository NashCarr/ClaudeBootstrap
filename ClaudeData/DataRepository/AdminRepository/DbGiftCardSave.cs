using System;
using System.Data;
using ClaudeData.Models.Admin;

namespace ClaudeData.DataRepository.AdminRepository
{
    public class DbGiftCardSave : DbSaveBase
    {
        public string AddUpdateRecord(GiftCard data)
        {
            if (string.IsNullOrEmpty(data.Name))
            {
                SetEmptyStringMessage("Gift Card");
                return ErrMsg;
            }

            try
            {
                IdValue = data.RecordId;
                IdParameter = "@GiftCardId";

                SetConnectToDatabase("[Admin].[usp_GiftCard_Upsert]");

                SetIdInputOutputParameter();

                CmdSql.Parameters.Add("@Name", SqlDbType.NVarChar, 50).Value = data.Name.Trim();
                CmdSql.Parameters.Add("@DisplayOrder", SqlDbType.Int).Value = data.DisplayOrder;
                CmdSql.Parameters.Add("@IsActive", SqlDbType.Bit).Value = data.IsActive;

                SetErrMsgParameter();

                SendNonQueryGetId();
            }
            catch (Exception ex)
            {
                ErrMsg = ex.Message;
            }
            return ErrMsg;
        }

        public string SetInactive(int giftCardId)
        {
            try
            {
                SetConnectToDatabase("[Admin].[usp_GiftCard_SetInactive]");

                CmdSql.Parameters.Add("@GiftCardId", SqlDbType.Int).Value = giftCardId;

                SetErrMsgParameter();

                SendNonQuery();
            }
            catch (Exception ex)
            {
                ErrMsg = ex.Message;
            }
            return ErrMsg;
        }
    }
}