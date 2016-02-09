using System;
using System.Data;
using ClaudeCommon.BaseModels;
using ClaudeCommon.Models;

namespace ClaudeData.DataRepository.AdminRepository
{
    public class DbGiftCardSave : DbSaveBase
    {
        public ReturnBase AddUpdateRecord(GiftCard data)
        {
            ReturnValues.Id = data.RecordId;

            if (string.IsNullOrEmpty(data.Name))
            {
                SetEmptyStringMessage("Gift Card");
                return ReturnValues;
            }

            try
            {
                ReturnValues.Id = data.RecordId;
                IdParameter = "@GiftCardId";

                SetConnectToDatabase("[Admin].[usp_GiftCard_Upsert]");

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

        public ReturnBase SetInactive(int recordId)
        {
            ReturnValues.Id = recordId;
            try
            {
                SetConnectToDatabase("[Admin].[usp_GiftCard_SetInactive]");

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

        public ReturnBase SetDisplayOrder(int recordId, int displayOrder)
        {
            ReturnValues.Id = recordId;
            try
            {
                SetConnectToDatabase("[Admin].[usp_GiftCard_SetDisplayOrder]");

                CmdSql.Parameters.Add("@GiftCardId", SqlDbType.Int).Value = ReturnValues.Id;
                CmdSql.Parameters.Add("@DisplayOrder", SqlDbType.Int).Value = displayOrder;

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