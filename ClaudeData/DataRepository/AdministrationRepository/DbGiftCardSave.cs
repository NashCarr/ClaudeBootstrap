using System;
using System.Data;
using CommonData.BaseModels.Returns;
using CommonData.Models.Administration;

namespace DataManagement.DataRepository.AdministrationRepository
{
    public class DbGiftCardSave : DbSaveBase
    {
        public ReturnBase SetInactive(int recordId)
        {
            ReturnValues.Id = recordId;
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

        public ReturnBase AddUpdateRecord(GiftCard data)
        {
            ReturnValues.Id = data.RecordId;

            if (!string.IsNullOrEmpty(data.Name)) return SaveRecord(data);

            SetEmptyStringMessage("Gift Card");
            return ReturnValues;
        }

        private ReturnBase SaveRecord(GiftCard data)
        {
            try
            {
                IdParameter = "@GiftCardId";

                SetConnectToDatabase("[GiftCard].[usp_Upsert]");

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