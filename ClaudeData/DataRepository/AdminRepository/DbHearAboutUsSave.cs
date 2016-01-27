using System;
using System.Data;
using ClaudeData.Models.Admin;

namespace ClaudeData.DataRepository.AdminRepository
{
    public class DbHearAboutUsSave : DbSaveBase
    {
        public string AddUpdateRecord(HearAboutUs data)
        {
            if (string.IsNullOrEmpty(data.Name))
            {
                SetEmptyStringMessage("Name");
                return ErrMsg;
            }

            try
            {
                IdValue = data.RecordId;
                IdParameter = "@HearAboutUsId";

                SetConnectToDatabase("[Admin].[usp_HearAboutUs_Upsert]");

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
                ErrMsg = ex.Message;
            }
            return ErrMsg;
        }

        public string SetInactive(int hearAboutUsId)
        {
            try
            {
                SetConnectToDatabase("[Admin].[usp_HearAboutUs_SetInactive]");

                CmdSql.Parameters.Add("@HearAboutUsId", SqlDbType.Int).Value = hearAboutUsId;

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