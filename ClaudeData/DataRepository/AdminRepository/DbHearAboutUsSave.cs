using System;
using System.Data;
using ClaudeCommon.BaseModels;
using ClaudeCommon.BaseModels.Returns;
using ClaudeCommon.Models;

namespace ClaudeData.DataRepository.AdminRepository
{
    public class DbHearAboutUsSave : DbSaveBase
    {
        public ReturnBase SetInactive(int recordId)
        {
            ReturnValues.Id = recordId;
            try
            {
                SetConnectToDatabase("[Admin].[usp_HearAboutUs_SetInactive]");

                CmdSql.Parameters.Add("@HearAboutUsId", SqlDbType.Int).Value = ReturnValues.Id;

                SetErrMsgParameter();

                SendNonQuery();
            }
            catch (Exception ex)
            {
                ReturnValues.ErrMsg = ex.Message;
            }

            return ReturnValues;
        }

        public ReturnBase AddUpdateRecord(HearAboutUs data)
        {
            ReturnValues.Id = data.RecordId;

            if (!string.IsNullOrEmpty(data.Name)) return SaveRecord(data);

            SetEmptyStringMessage("Hear About Us");
            return ReturnValues;
        }

        private ReturnBase SaveRecord(HearAboutUs data)
        {
            try
            {
                IdParameter = "@HearAboutUsId";

                SetConnectToDatabase("[Admin].[usp_HearAboutUs_Upsert]");

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